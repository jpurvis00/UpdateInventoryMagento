
using UpdateInventoryMagentoUI;
using Magento2ConnectorLibrary.Models;

internal class Program
{
    private static async Task Main(string[] args)
    {
        Configuration config = new();
        config.InitializeConfiguration();

        ApiResponseModel apiResponse = new ApiResponseModel();

        using HttpClient client = new();

        GetAllOCInventoryFromAPI getAllOCInventoryFromApi = new GetAllOCInventoryFromAPI(client);

        var allOmegaCubeInventory = await getAllOCInventoryFromApi.GetAllInventory();

        var token = MagentoToken.GetTokenFromMagento(config.userName, config.password, config.url);

        /* The token is only good for a few hours. I need to pull it everytime I run the 
         * application. It is also returned within quotes. Next line removes the quotes so 
         * that it can connect properly.
         */
        token = token.Substring(1, token.Length - 2);

        var allMagentoInventory = GetMagentoSkus.GetAllMagentoSkus(apiResponse, config.url, token);

        var updateTheFollowingInventory = CheckForInventoryUpdates.CheckIfInventoryNeedsToBeUpdated(allOmegaCubeInventory, allMagentoInventory);

        UpdateMagentoProductQty.UpdateProductQty(updateTheFollowingInventory, config.url, token);

        Console.WriteLine("Finished processing inventory records.");
        Console.ReadLine();
    }
}