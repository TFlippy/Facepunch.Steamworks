using Steamworks.Data;
using System.Runtime.InteropServices;

namespace Steamworks
{
	public struct Controller
	{
		public InputHandle_t Handle;

		public Controller(InputHandle_t inputHandle_t)
		{
			this.Handle = inputHandle_t;
		}

		public ulong Id => this.Handle.Value;
		public InputType InputType => SteamInput.Internal.GetInputTypeForHandle(this.Handle);

		/// <summary>
		/// Reconfigure the controller to use the specified action set (ie 'Menu', 'Walk' or 'Drive')
		/// This is cheap, and can be safely called repeatedly. It's often easier to repeatedly call it in
		/// our state loops, instead of trying to place it in all of your state transitions.
		/// </summary>
		public string ActionSet
		{
			set => SteamInput.Internal.ActivateActionSet(this.Handle, SteamInput.Internal.GetActionSetHandle(value));
		}

		public void DeactivateLayer(string layer)
		{
			SteamInput.Internal.DeactivateActionSetLayer(this.Handle, SteamInput.Internal.GetActionSetHandle(layer));
		}

		public void ActivateLayer(string layer)
		{
			SteamInput.Internal.ActivateActionSetLayer(this.Handle, SteamInput.Internal.GetActionSetHandle(layer));
		}

		public void ClearLayers()
		{
			SteamInput.Internal.DeactivateAllActionSetLayers(this.Handle);
		}


		/// <summary>
		/// Returns the current state of the supplied digital game action
		/// </summary>
		public DigitalState GetDigitalState(string actionName)
		{
			return SteamInput.Internal.GetDigitalActionData(this.Handle, SteamInput.GetDigitalActionHandle(actionName));
		}

		/// <summary>
		/// Returns the current state of these supplied analog game action
		/// </summary>
		public AnalogState GetAnalogState(string actionName)
		{
			return SteamInput.Internal.GetAnalogActionData(this.Handle, SteamInput.GetAnalogActionHandle(actionName));
		}


		public override string ToString()
		{
			return $"{this.InputType}.{this.Handle.Value}";
		}

		public static bool operator ==(Controller a, Controller b) => a.Equals(b);
		public static bool operator !=(Controller a, Controller b) => !(a == b);
		public override bool Equals(object p)
		{
			return this.Equals((Controller)p);
		}

		public override int GetHashCode()
		{
			return this.Handle.GetHashCode();
		}

		public bool Equals(Controller p)
		{
			return p.Handle == this.Handle;
		}
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct AnalogState
	{
		public InputSourceMode EMode; // eMode EInputSourceMode
		public float X; // x float
		public float Y; // y float
		public byte BActive; // bActive byte
		public bool Active => this.BActive != 0;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct MotionState
	{
		public float RotQuatX; // rotQuatX float
		public float RotQuatY; // rotQuatY float
		public float RotQuatZ; // rotQuatZ float
		public float RotQuatW; // rotQuatW float
		public float PosAccelX; // posAccelX float
		public float PosAccelY; // posAccelY float
		public float PosAccelZ; // posAccelZ float
		public float RotVelX; // rotVelX float
		public float RotVelY; // rotVelY float
		public float RotVelZ; // rotVelZ float
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct DigitalState
	{
		[MarshalAs(UnmanagedType.I1)]
		public byte BState; // bState byte
		[MarshalAs(UnmanagedType.I1)]
		public byte BActive; // bActive byte

		public bool Pressed => this.BState != 0;
		public bool Active => this.BActive != 0;
	}
}