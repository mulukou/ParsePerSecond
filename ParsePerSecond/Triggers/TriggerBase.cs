using Newtonsoft.Json;

namespace ParsePerSecond.Triggers
{
	public abstract class TriggerBase
	{
		private string name = "";
		private bool enabled = true;

		public string Name
		{
			get => this.name;
			set => this.name = value;
		}

		public bool Enabled
		{
			get => this.enabled;
			set => this.enabled = value;
		}

		[JsonIgnore]
		public bool IsAttached { get; private set; }

		public virtual void Attach()
		{
			this.IsAttached = true;
		}

		public virtual void Detach()
		{
			this.IsAttached = false;
		}
	}
}