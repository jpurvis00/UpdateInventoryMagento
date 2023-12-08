
using Magento2ConnectorLibrary;
using Magento2ConnectorLibrary.Models;

public static class GetMagentoSkus
{

    public static ApiResponseModel GetAllMagentoSkus(ApiResponseModel apiResponse, string url, string token)
    {
        int page = 1;
        var magento = new GetSkus(url);
        apiResponse = magento.GetAllSkus(apiResponse, page, token);

        /* Since the magento api limits the return # to 300, I get the total count of records
         * from the original json request.  I divide it by 300.00 and then use the floor method
         * to reduce my loop by 1 less than needed.  
         * Ex. 2455 / 300.00 = 8.18
         * I would need to call the api 9 times to get all my values. Since I've already called 
         * it once to get my count, I use the floor method so that I only call the api 8 more times, 
         * for a total of 9 calls which retrieves all records. This only works if the result of the
         * division is not a whole #. If that happens, I subtract 1 so I don't do 1 too many
         * requests.
         */
        var pages = apiResponse.TotalCount / 300.00;

        if (pages % 2 != 0)
        {
            pages = Math.Floor(pages);
        }
        else
        {
            pages -= 1;
        }

        for (int i = 0; i < pages; ++i)
        {
            apiResponse = magento.GetAllSkus(apiResponse, (page + i + 1), token);
        }

        return apiResponse;
    }
}