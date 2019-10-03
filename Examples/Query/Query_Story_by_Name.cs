using VersionOne.SDK.API.Asset;
using static System.Console;

namespace Examples
{
	public class Query_Story_by_Name
	{
		string instanceUrl = "https://www16.v1host.com/api-examples/api/asset";
		string accessToken = "1.bndNO51GiliELZu1bbQdq3omgRI=";

		static void Main()
		{
			var example = new Query_Story_by_Name();
			example.Execute();
			WriteLine("Press any key to exit...");
			ReadKey();
		}

		public void Execute()
		{
            var v1 = new AssetClient(instanceUrl, accessToken);

            var assets = v1
				.Query("Story")
				.Where("Name", "Hello, Lifecycle!")
				.Select("Name", "Number")
				.Retrieve();

			foreach (dynamic story in assets)
			{
				WriteLine(story.Oid);
				WriteLine(story.Name);
				WriteLine(story.Number);
			}
		}
	}
}