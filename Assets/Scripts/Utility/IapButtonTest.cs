using UnityEngine;
using UnityEngine.Purchasing;

namespace Utility
{
    public class IapButtonTest : MonoBehaviour
    {
        [SerializeField] private CodelessIAPButton _iapButton;

        private void Start()
        {
            var productId = _iapButton.productId;
            var product = CodelessIAPStoreListener.Instance.GetProduct(productId);
            if (product == null)
            {
               _iapButton.onProductFetched.AddListener(UpdateProductPrice);
            }
            else
            {
                UpdateProductPrice(product);
            }
        }

        private void UpdateProductPrice(Product product)
        {
            Debug.Log("product.metadata.localizedDescription = " + product.metadata.localizedDescription);
            Debug.Log("product.metadata.localizedPrice = " + product.metadata.localizedPrice);
            Debug.Log("product.metadata.localizedTitle = " + product.metadata.localizedTitle);
            Debug.Log("product.metadata.isoCurrencyCode = " + product.metadata.isoCurrencyCode);
            Debug.Log("product.metadata.localizedPriceString = " + product.metadata.localizedPriceString);
        }
    }
}