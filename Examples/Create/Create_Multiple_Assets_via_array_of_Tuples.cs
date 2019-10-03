using VersionOne.SDK.API.Asset;
using static System.Console;
using static VersionOne.SDK.API.Asset.ClientUtilities;

namespace Examples
{
	public class Create_Multiple_Assets_via_array_of_tuples
	{
		string instanceUrl = "https://www16.v1host.com/api-examples/api/asset";
		string accessToken = "1.bndNO51GiliELZu1bbQdq3omgRI=";

		static void Main()
		{
			var example = new Create_Multiple_Assets_via_array_of_tuples();
			example.Execute();
			WriteLine("Press any key to exit...");
			ReadKey();
		}

		public void Execute()
		{
            var v1 = new AssetClient(instanceUrl, accessToken);

            dynamic result = v1.Create(
				Asset(
					("AssetType", "Story"),
					("Scope", "Scope:0"),
					("Name", "Story 1 from Tuple")
				),
				Asset(
					("AssetType", "Story"),
					("Scope", "Scope:0"),
					("Name", "Story 2 from Tuple")
				),				
				Asset(
					("AssetType", "Story"),
					("Scope", "Scope:0"),
					("Name", "Story 3 from Tuple")
				),
				Asset(
					("AssetType", "Story"),
					("Scope", "Scope:0"),
					("Name", "Story 4 from Tuple")
				)
			);

			WriteLine("Result returned from .Create with multiple assets:");
			WriteLine(result);
		}
	}
}
