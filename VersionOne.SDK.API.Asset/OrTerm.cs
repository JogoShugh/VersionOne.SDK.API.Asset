using System.Collections.Generic;
using System.Linq;

namespace VersionOne.SDK.API.Asset
{
	public class OrTerm : Term
	{
		public List<Term> Terms = new List<Term>();

		public OrTerm(params Term[] terms)
		{
			Terms.AddRange(terms);
		}

		public override string ToQueryStringParameter()
		{
			var encodedTerms = Terms.Select(c => c.ToQueryStringParameter());

			return $"({string.Join("|", encodedTerms)})";
		}
	}
}