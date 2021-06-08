using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Steamworks.Data;


namespace Steamworks
{
	public class ISteamController : SteamInterface
	{
		
		public ISteamController( bool IsGameServer )
		{
			SetupInterface( IsGameServer );
		}
		
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamController_v008", CallingConvention = Platform.CC)]
		public static extern IntPtr SteamAPI_SteamController_v008();
		public override IntPtr GetUserInterfacePointer() => SteamAPI_SteamController_v008();
		
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_Init", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _Init( IntPtr self );
		
		#endregion
		public bool Init()
		{
			var returnValue = _Init( Self );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_Shutdown", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _Shutdown( IntPtr self );
		
		#endregion
		public bool Shutdown()
		{
			var returnValue = _Shutdown( Self );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_RunFrame", CallingConvention = Platform.CC)]
		public static extern void _RunFrame( IntPtr self );
		
		#endregion
		public void RunFrame()
		{
			_RunFrame( Self );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_GetConnectedControllers", CallingConvention = Platform.CC)]
		public static extern int _GetConnectedControllers( IntPtr self, [In,Out] ControllerHandle_t[]  handlesOut );
		
		#endregion
		public int GetConnectedControllers( [In,Out] ControllerHandle_t[]  handlesOut )
		{
			var returnValue = _GetConnectedControllers( Self, handlesOut );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_GetActionSetHandle", CallingConvention = Platform.CC)]
		public static extern ControllerActionSetHandle_t _GetActionSetHandle( IntPtr self, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pszActionSetName );
		
		#endregion
		public ControllerActionSetHandle_t GetActionSetHandle( [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pszActionSetName )
		{
			var returnValue = _GetActionSetHandle( Self, pszActionSetName );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_ActivateActionSet", CallingConvention = Platform.CC)]
		public static extern void _ActivateActionSet( IntPtr self, ControllerHandle_t controllerHandle, ControllerActionSetHandle_t actionSetHandle );
		
		#endregion
		public void ActivateActionSet( ControllerHandle_t controllerHandle, ControllerActionSetHandle_t actionSetHandle )
		{
			_ActivateActionSet( Self, controllerHandle, actionSetHandle );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_GetCurrentActionSet", CallingConvention = Platform.CC)]
		public static extern ControllerActionSetHandle_t _GetCurrentActionSet( IntPtr self, ControllerHandle_t controllerHandle );
		
		#endregion
		public ControllerActionSetHandle_t GetCurrentActionSet( ControllerHandle_t controllerHandle )
		{
			var returnValue = _GetCurrentActionSet( Self, controllerHandle );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_ActivateActionSetLayer", CallingConvention = Platform.CC)]
		public static extern void _ActivateActionSetLayer( IntPtr self, ControllerHandle_t controllerHandle, ControllerActionSetHandle_t actionSetLayerHandle );
		
		#endregion
		public void ActivateActionSetLayer( ControllerHandle_t controllerHandle, ControllerActionSetHandle_t actionSetLayerHandle )
		{
			_ActivateActionSetLayer( Self, controllerHandle, actionSetLayerHandle );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_DeactivateActionSetLayer", CallingConvention = Platform.CC)]
		public static extern void _DeactivateActionSetLayer( IntPtr self, ControllerHandle_t controllerHandle, ControllerActionSetHandle_t actionSetLayerHandle );
		
		#endregion
		public void DeactivateActionSetLayer( ControllerHandle_t controllerHandle, ControllerActionSetHandle_t actionSetLayerHandle )
		{
			_DeactivateActionSetLayer( Self, controllerHandle, actionSetLayerHandle );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_DeactivateAllActionSetLayers", CallingConvention = Platform.CC)]
		public static extern void _DeactivateAllActionSetLayers( IntPtr self, ControllerHandle_t controllerHandle );
		
		#endregion
		public void DeactivateAllActionSetLayers( ControllerHandle_t controllerHandle )
		{
			_DeactivateAllActionSetLayers( Self, controllerHandle );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_GetActiveActionSetLayers", CallingConvention = Platform.CC)]
		public static extern int _GetActiveActionSetLayers( IntPtr self, ControllerHandle_t controllerHandle, [In,Out] ControllerActionSetHandle_t[]  handlesOut );
		
		#endregion
		public int GetActiveActionSetLayers( ControllerHandle_t controllerHandle, [In,Out] ControllerActionSetHandle_t[]  handlesOut )
		{
			var returnValue = _GetActiveActionSetLayers( Self, controllerHandle, handlesOut );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_GetDigitalActionHandle", CallingConvention = Platform.CC)]
		public static extern ControllerDigitalActionHandle_t _GetDigitalActionHandle( IntPtr self, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pszActionName );
		
		#endregion
		public ControllerDigitalActionHandle_t GetDigitalActionHandle( [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pszActionName )
		{
			var returnValue = _GetDigitalActionHandle( Self, pszActionName );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_GetDigitalActionData", CallingConvention = Platform.CC)]
		public static extern DigitalState _GetDigitalActionData( IntPtr self, ControllerHandle_t controllerHandle, ControllerDigitalActionHandle_t digitalActionHandle );
		
		#endregion
		public DigitalState GetDigitalActionData( ControllerHandle_t controllerHandle, ControllerDigitalActionHandle_t digitalActionHandle )
		{
			var returnValue = _GetDigitalActionData( Self, controllerHandle, digitalActionHandle );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_GetDigitalActionOrigins", CallingConvention = Platform.CC)]
		public static extern int _GetDigitalActionOrigins( IntPtr self, ControllerHandle_t controllerHandle, ControllerActionSetHandle_t actionSetHandle, ControllerDigitalActionHandle_t digitalActionHandle, ref ControllerActionOrigin originsOut );
		
		#endregion
		public int GetDigitalActionOrigins( ControllerHandle_t controllerHandle, ControllerActionSetHandle_t actionSetHandle, ControllerDigitalActionHandle_t digitalActionHandle, ref ControllerActionOrigin originsOut )
		{
			var returnValue = _GetDigitalActionOrigins( Self, controllerHandle, actionSetHandle, digitalActionHandle, ref originsOut );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_GetAnalogActionHandle", CallingConvention = Platform.CC)]
		public static extern ControllerAnalogActionHandle_t _GetAnalogActionHandle( IntPtr self, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pszActionName );
		
		#endregion
		public ControllerAnalogActionHandle_t GetAnalogActionHandle( [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pszActionName )
		{
			var returnValue = _GetAnalogActionHandle( Self, pszActionName );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_GetAnalogActionData", CallingConvention = Platform.CC)]
		public static extern AnalogState _GetAnalogActionData( IntPtr self, ControllerHandle_t controllerHandle, ControllerAnalogActionHandle_t analogActionHandle );
		
		#endregion
		public AnalogState GetAnalogActionData( ControllerHandle_t controllerHandle, ControllerAnalogActionHandle_t analogActionHandle )
		{
			var returnValue = _GetAnalogActionData( Self, controllerHandle, analogActionHandle );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_GetAnalogActionOrigins", CallingConvention = Platform.CC)]
		public static extern int _GetAnalogActionOrigins( IntPtr self, ControllerHandle_t controllerHandle, ControllerActionSetHandle_t actionSetHandle, ControllerAnalogActionHandle_t analogActionHandle, ref ControllerActionOrigin originsOut );
		
		#endregion
		public int GetAnalogActionOrigins( ControllerHandle_t controllerHandle, ControllerActionSetHandle_t actionSetHandle, ControllerAnalogActionHandle_t analogActionHandle, ref ControllerActionOrigin originsOut )
		{
			var returnValue = _GetAnalogActionOrigins( Self, controllerHandle, actionSetHandle, analogActionHandle, ref originsOut );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_GetGlyphForActionOrigin", CallingConvention = Platform.CC)]
		public static extern Utf8StringPointer _GetGlyphForActionOrigin( IntPtr self, ControllerActionOrigin eOrigin );
		
		#endregion
		public string GetGlyphForActionOrigin( ControllerActionOrigin eOrigin )
		{
			var returnValue = _GetGlyphForActionOrigin( Self, eOrigin );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_GetStringForActionOrigin", CallingConvention = Platform.CC)]
		public static extern Utf8StringPointer _GetStringForActionOrigin( IntPtr self, ControllerActionOrigin eOrigin );
		
		#endregion
		public string GetStringForActionOrigin( ControllerActionOrigin eOrigin )
		{
			var returnValue = _GetStringForActionOrigin( Self, eOrigin );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_StopAnalogActionMomentum", CallingConvention = Platform.CC)]
		public static extern void _StopAnalogActionMomentum( IntPtr self, ControllerHandle_t controllerHandle, ControllerAnalogActionHandle_t eAction );
		
		#endregion
		public void StopAnalogActionMomentum( ControllerHandle_t controllerHandle, ControllerAnalogActionHandle_t eAction )
		{
			_StopAnalogActionMomentum( Self, controllerHandle, eAction );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_GetMotionData", CallingConvention = Platform.CC)]
		public static extern MotionState _GetMotionData( IntPtr self, ControllerHandle_t controllerHandle );
		
		#endregion
		public MotionState GetMotionData( ControllerHandle_t controllerHandle )
		{
			var returnValue = _GetMotionData( Self, controllerHandle );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_TriggerHapticPulse", CallingConvention = Platform.CC)]
		public static extern void _TriggerHapticPulse( IntPtr self, ControllerHandle_t controllerHandle, SteamControllerPad eTargetPad, ushort usDurationMicroSec );
		
		#endregion
		public void TriggerHapticPulse( ControllerHandle_t controllerHandle, SteamControllerPad eTargetPad, ushort usDurationMicroSec )
		{
			_TriggerHapticPulse( Self, controllerHandle, eTargetPad, usDurationMicroSec );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_TriggerRepeatedHapticPulse", CallingConvention = Platform.CC)]
		public static extern void _TriggerRepeatedHapticPulse( IntPtr self, ControllerHandle_t controllerHandle, SteamControllerPad eTargetPad, ushort usDurationMicroSec, ushort usOffMicroSec, ushort unRepeat, uint nFlags );
		
		#endregion
		public void TriggerRepeatedHapticPulse( ControllerHandle_t controllerHandle, SteamControllerPad eTargetPad, ushort usDurationMicroSec, ushort usOffMicroSec, ushort unRepeat, uint nFlags )
		{
			_TriggerRepeatedHapticPulse( Self, controllerHandle, eTargetPad, usDurationMicroSec, usOffMicroSec, unRepeat, nFlags );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_TriggerVibration", CallingConvention = Platform.CC)]
		public static extern void _TriggerVibration( IntPtr self, ControllerHandle_t controllerHandle, ushort usLeftSpeed, ushort usRightSpeed );
		
		#endregion
		public void TriggerVibration( ControllerHandle_t controllerHandle, ushort usLeftSpeed, ushort usRightSpeed )
		{
			_TriggerVibration( Self, controllerHandle, usLeftSpeed, usRightSpeed );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_SetLEDColor", CallingConvention = Platform.CC)]
		public static extern void _SetLEDColor( IntPtr self, ControllerHandle_t controllerHandle, byte nColorR, byte nColorG, byte nColorB, uint nFlags );
		
		#endregion
		public void SetLEDColor( ControllerHandle_t controllerHandle, byte nColorR, byte nColorG, byte nColorB, uint nFlags )
		{
			_SetLEDColor( Self, controllerHandle, nColorR, nColorG, nColorB, nFlags );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_ShowBindingPanel", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _ShowBindingPanel( IntPtr self, ControllerHandle_t controllerHandle );
		
		#endregion
		public bool ShowBindingPanel( ControllerHandle_t controllerHandle )
		{
			var returnValue = _ShowBindingPanel( Self, controllerHandle );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_GetInputTypeForHandle", CallingConvention = Platform.CC)]
		public static extern InputType _GetInputTypeForHandle( IntPtr self, ControllerHandle_t controllerHandle );
		
		#endregion
		public InputType GetInputTypeForHandle( ControllerHandle_t controllerHandle )
		{
			var returnValue = _GetInputTypeForHandle( Self, controllerHandle );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_GetControllerForGamepadIndex", CallingConvention = Platform.CC)]
		public static extern ControllerHandle_t _GetControllerForGamepadIndex( IntPtr self, int nIndex );
		
		#endregion
		public ControllerHandle_t GetControllerForGamepadIndex( int nIndex )
		{
			var returnValue = _GetControllerForGamepadIndex( Self, nIndex );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_GetGamepadIndexForController", CallingConvention = Platform.CC)]
		public static extern int _GetGamepadIndexForController( IntPtr self, ControllerHandle_t ulControllerHandle );
		
		#endregion
		public int GetGamepadIndexForController( ControllerHandle_t ulControllerHandle )
		{
			var returnValue = _GetGamepadIndexForController( Self, ulControllerHandle );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_GetStringForXboxOrigin", CallingConvention = Platform.CC)]
		public static extern Utf8StringPointer _GetStringForXboxOrigin( IntPtr self, XboxOrigin eOrigin );
		
		#endregion
		public string GetStringForXboxOrigin( XboxOrigin eOrigin )
		{
			var returnValue = _GetStringForXboxOrigin( Self, eOrigin );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_GetGlyphForXboxOrigin", CallingConvention = Platform.CC)]
		public static extern Utf8StringPointer _GetGlyphForXboxOrigin( IntPtr self, XboxOrigin eOrigin );
		
		#endregion
		public string GetGlyphForXboxOrigin( XboxOrigin eOrigin )
		{
			var returnValue = _GetGlyphForXboxOrigin( Self, eOrigin );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_GetActionOriginFromXboxOrigin", CallingConvention = Platform.CC)]
		public static extern ControllerActionOrigin _GetActionOriginFromXboxOrigin( IntPtr self, ControllerHandle_t controllerHandle, XboxOrigin eOrigin );
		
		#endregion
		public ControllerActionOrigin GetActionOriginFromXboxOrigin( ControllerHandle_t controllerHandle, XboxOrigin eOrigin )
		{
			var returnValue = _GetActionOriginFromXboxOrigin( Self, controllerHandle, eOrigin );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_TranslateActionOrigin", CallingConvention = Platform.CC)]
		public static extern ControllerActionOrigin _TranslateActionOrigin( IntPtr self, InputType eDestinationInputType, ControllerActionOrigin eSourceOrigin );
		
		#endregion
		public ControllerActionOrigin TranslateActionOrigin( InputType eDestinationInputType, ControllerActionOrigin eSourceOrigin )
		{
			var returnValue = _TranslateActionOrigin( Self, eDestinationInputType, eSourceOrigin );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_GetControllerBindingRevision", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _GetControllerBindingRevision( IntPtr self, ControllerHandle_t controllerHandle, ref int pMajor, ref int pMinor );
		
		#endregion
		public bool GetControllerBindingRevision( ControllerHandle_t controllerHandle, ref int pMajor, ref int pMinor )
		{
			var returnValue = _GetControllerBindingRevision( Self, controllerHandle, ref pMajor, ref pMinor );
			return returnValue;
		}
		
	}
}
