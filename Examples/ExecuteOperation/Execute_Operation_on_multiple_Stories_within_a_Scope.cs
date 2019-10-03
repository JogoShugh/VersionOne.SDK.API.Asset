using System.Collections.Generic;
using VersionOne.SDK.API.Asset;
using static System.Console;
using static VersionOne.SDK.API.Asset.ClientUtilities;
using static VersionOne.SDK.API.Asset.ComparisonFunctions;

namespace Examples
{
	public class Execute_Operation_on_multiple_Stories_within_a_Scope
	{
		string instanceUrl = "https://www16.v1host.com/api-examples/api/asset";
		string accessToken = "1.bndNO51GiliELZu1bbQdq3omgRI=";

		static void Main()
		{
			var example = new Execute_Operation_on_multiple_Stories_within_a_Scope();
			example.Execute();
			WriteLine("Press any key to exit...");
				ReadKey();
		}

		public void Execute()
		{
            var v1 = new AssetClient(instanceUrl, accessToken);

            dynamic epic = v1.Create(
				("AssetType", "Epic"),
				("Scope", "Scope:0"),
				("Name", "Epic with four Stories"),
				("Subs", Assets(
					Asset(
						("AssetType", "Story"),
						("Name", "Story in Epic")
					),
					Asset(
						("AssetType", "Story"),
						("Name", "Story in Epic")
					),
					Asset(
						("AssetType", "Story"),
						("Name", "Story in Epic")
					),
					Asset(
						("AssetType", "Story"),
						("Name", "Story in Epic")
					)
				))
			);

			IEnumerable<string> assetsOperatedOn = v1.ExecuteOperation(
				From("Story")
				.Where(
					Equal("Name", "Story in Epic"),
					Equal("Scope", "Scope:0"),
					Equal("Super", epic.Oid)
				), "QuickClose");

			WriteLine("Operated on the following Assets: " + string.Join(", ", assetsOperatedOn));
		}
	}
}
