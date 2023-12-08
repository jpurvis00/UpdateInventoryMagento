
using Magento2ConnectorLibrary;

public class MagentoToken
{
    public static string GetTokenFromMagento(string userName, string password, string url)
    {
        var magento = new GetMagentoAdminToken(url);
        return magento.GetAdminToken(userName, password);
    }
}