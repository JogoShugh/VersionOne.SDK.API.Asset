using System.Collections.Generic;
using VersionOne.SDK.API.Asset;
using static System.Console;
using static VersionOne.SDK.API.Asset.ClientUtilities;
using static VersionOne.SDK.API.Asset.ComparisonFunctions;

namespace Examples
{
	public class Update_multiple_newly_created_Stories_within_a_Scope
	{
		string instanceUrl = "https://www16.v1host.com/api-examples/api/asset";
		string accessToken = "1.bndNO51GiliELZu1bbQdq3omgRI=";

		static void Main()
		{
			var example = new Update_multiple_newly_created_Stories_within_a_Scope();
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
						("Name", "Another Story in Epic")
					),
					Asset(
						("AssetType", "Story"),
						("Name", "Story in Epic")
					),
					Asset(
						("AssetType", "Story"),
						("Name", "Another Story in Epic")
					)
				))
			);

			IEnumerable<string> updated = v1.Update(
				From("Story")
				.Where(
					Equal("Name", "Story in Epic", "Another Story in Epic"),
					Equal("Scope", "Scope:0"),
					Equal("Super", epic.Oid)
				), new
				{
					Description = "Updated via bulk API"
				});

			WriteLine("Updated the following Assets: " + string.Join(", ", updated));
		}
	}
}
