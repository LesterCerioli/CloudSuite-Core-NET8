namespace CloudSuite.Domain.Rxceptions
{
	public abstract class ApplicationException : Exception
	{
		protected ApplicationException(string title, string message)
			: base(message) =>
			Title = title;

		public string Title { get; }
	}
}