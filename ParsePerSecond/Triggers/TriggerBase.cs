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

		public virtual int CooldownLeft => 0;

		[JsonIgnore]
		public bool IsAttached { get; private set; }
		public int DeviceGroup { get; set; } = 0;

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