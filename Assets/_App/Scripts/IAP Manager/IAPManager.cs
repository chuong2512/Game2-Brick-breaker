using UnityEngine.Purchasing.Security;
using System;
using System.Collections;
using Jackal;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPKey
{
    public const string PACK1 = "add50";
    public const string PACK2 = "add200";
    public const string PACK3 = "add500";
    public const string PACK4 = "add1000";
}

public class IAPManager : PersistentSingleton<IAPManager>, IStoreListener
{
    private static IStoreController storeController;
    private static IExtensionProvider extensionProvider;
    public static Action OnPurchaseSuccess;

    private bool _isBuyFromShop;

    private void Start()
    {
        InitIAP();
    }

    private void InitIAP()
    {
        if (storeController == null)
        {
            InitProduct();
        }
    }

    private void InitProduct()
    {
        if (IsInitialized())
        {
            return;
        }

        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        builder.AddProduct(IAPKey.PACK1, ProductType.Consumable);
        builder.AddProduct(IAPKey.PACK2, ProductType.Consumable);
        builder.AddProduct(IAPKey.PACK3, ProductType.Consumable);
        builder.AddProduct(IAPKey.PACK4, ProductType.Consumable);
        UnityPurchasing.Initialize(this, builder);
    }

    public void BuyProductID(string productId)
    {
        _isBuyFromShop = true;

#if UNITY_EDITOR
        OnPurchaseComplete(productId);
#else
            // If Purchasing has been initialized ...
            if (IsInitialized())
            {
                Product product = storeController.products.WithID(productId);

                if (product != null && product.availableToPurchase)
                {
                    Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
                    storeController.InitiatePurchase(product);
                }
                else
                {
                    // ... report the product look-up failure situation  
                    Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
                }
            }
            else
            {
                // ... report the fact Purchasing has not succeeded initializing yet. Consider waiting longer or 
                // retrying initialization.
                Debug.Log("BuyProductID FAIL. Not initialized.");
            }
#endif
    }

    private bool IsInitialized()
    {
        // Only say we are initialized if both the Purchasing references are set.
        return storeController != null && extensionProvider != null;
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        // Purchasing has succeeded initializing. Collect our Purchasing references.
        Debug.Log("OnInitialized: PASS");

        // Overall Purchasing system, configured with products for this application.
        storeController = controller;
        // Store specific subsystem, for accessing device-specific store features.
        extensionProvider = extensions;
    }

    public void RestorePurchases(System.Action<bool> OnRestored)
    {
        // If Purchasing has not yet been set up ...
        if (!IsInitialized())
        {
            // ... report the situation and stop restoring. Consider either waiting longer, or retrying initialization.
            Debug.Log("RestorePurchases FAIL. Not initialized.");
            OnRestored?.Invoke(false);
            return;
        }

        // If we are running on an Apple device ... 
        if (Application.platform == RuntimePlatform.IPhonePlayer ||
            Application.platform == RuntimePlatform.OSXPlayer)
        {
            Debug.Log("RestorePurchases started ...");

            var apple = extensionProvider.GetExtension<IAppleExtensions>();
            apple.RestoreTransactions((result) =>
            {
                Debug.Log("Transactions restored: " + (result ? "Succeed" : "Failed"));
                OnRestored?.Invoke(result);
            });
        }
        else
        {
            Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
            OnRestored?.Invoke(false);
        }
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        bool validPurchase = true; // Presume valid for platforms with no R.V.

        // Unity IAP's validation logic is only included on these platforms.
#if UNITY_ANDROID || UNITY_IOS || UNITY_STANDALONE_OSX
        // Prepare the validator with the secrets we prepared in the Editor
        // obfuscation window.
        var validator = new CrossPlatformValidator(GooglePlayTangle.Data(), AppleTangle.Data(), Application.identifier);
        try
        {
            // On Google Play, result has a single product ID.
            // On Apple stores, receipts contain multiple products.
            var result = validator.Validate(args.purchasedProduct.receipt);

            // If Restore Purchase, handle it here and do not Log
            if (!_isBuyFromShop)
            {
                HandleRestorePurchase(args.purchasedProduct.definition.id);
                return PurchaseProcessingResult.Complete;
            }

            // For informational purposes, we list the receipt(s)
            Debug.Log("Receipt is valid. Contents:");
            foreach (IPurchaseReceipt productReceipt in result)
            {
                Debug.Log(productReceipt.productID);
                Debug.Log(productReceipt.purchaseDate);
                Debug.Log(productReceipt.transactionID);

                if (Application.platform == RuntimePlatform.Android)
                {
                    var googleReceipt = (GooglePlayReceipt) productReceipt;
                    var pId = googleReceipt.productID;
                    var metadata = storeController.products.WithID(pId).metadata;
                }

                if (Application.platform == RuntimePlatform.IPhonePlayer)
                {
                    var appleReceipt = (AppleInAppPurchaseReceipt) productReceipt;
                    var pId = appleReceipt.productID;
                    var metadata = storeController.products.WithID(pId).metadata;
                }
            }
        }
        catch (IAPSecurityException)
        {
            Debug.Log("Invalid receipt, not unlocking content");
            validPurchase = false;
        }
#endif

        _isBuyFromShop = false;
        if (validPurchase)
        {
            // Unlock the appropriate content here.
            OnPurchaseComplete(args.purchasedProduct.definition.id);
        }

        // Return a flag indicating whether this product has completely been received, or if the application needs 
        // to be reminded of this purchase at next app launch. Use PurchaseProcessingResult.Pending when still 
        // saving purchased products to the cloud, and when that save is delayed. 
        return PurchaseProcessingResult.Complete;
    }

    private void HandleRestorePurchase(string productId)
    {
        StartCoroutine(CoHandleRestore(productId));
    }

    private void OnPurchaseComplete(string productId)
    {
        OnPurchaseSuccess?.Invoke();
    }

    private void BuyPack()
    {
        //todo: buy pack
    }


    private IEnumerator CoHandleRestore(string productId)
    {
        yield return new WaitForSeconds(0.15f);
    }

    public static string GetLocalizePrice(string key, string defaultPriceText)
    {
        if (storeController != null)
            return storeController.products.WithID(key).metadata.localizedPriceString;
        return defaultPriceText;
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}",
            product.definition.storeSpecificId, failureReason));
    }
}