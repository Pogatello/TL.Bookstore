using System.ComponentModel.DataAnnotations.Schema;
using TL.Bookstore.Infrastructure.Exceptions;

namespace TL.Bookstore.Model.Common
{
	public class ValidationEntity
	{
		#region Properties

		[NotMapped]
		public List<string> BrokenRules { get; set; }

		#endregion

		#region Public Methods

		public void AddBrokenRule(string message)
		{
			BrokenRules.Add(message);
		}

		public void ThrowExceptionIfThereAreBrokenRules()
		{
			if (BrokenRules.Any())
			{
				throw new ValidationEntityException(FormatBrokenRulesForExceptionMessage());
			}
		}

		#endregion

		#region Private Methods

		private string FormatBrokenRulesForExceptionMessage()
		{
			return String.Join(Environment.NewLine, BrokenRules);
		}

		#endregion
	}
}
