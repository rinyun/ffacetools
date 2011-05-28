using System;
using System.Collections.Generic;

namespace FFACETools {
	public partial class FFACE {
		/// <summary>
		/// Class container to impliment Pyrolol's navigation system
		/// </summary>
		public class NavigatorTools {
			#region Members

			/// <summary>
			/// Our link to the Player Tools
			/// </summary>
			private FFACE _FFACE { get; set; }

			/// <summary>
			/// Wehther we are current moving or not
			/// </summary>
			private bool _IsRunning = false;

			/// <summary>
			/// How close to the heading we must be
			/// </summary>
			public uint HeadingTolerance { get; set; }

			/// <summary>
			/// How close to the locatin we must be
			/// </summary>
			public double DistanceTolerance { get; set; }

			/// <summary>
			/// How long before we should check our current distance (in ms)
			/// </summary>
			public int SpeedDelay { get; set; }

			/// <summary>
			/// How long to stay running for
			/// </summary>
			public float StayRunningAmount { get; set; }

			/// <summary>
			/// Delegate option 
			/// </summary>
			public delegate float dPoint();

			/// <summary>
			/// How long before checking current position and adjusting
			/// </summary>
			public int GotoDelay { get; set; }

			#endregion

			#region Constructor

			/// <summary>
			/// Contructor to start navigation system
			/// </summary>
			/// <param name="player">Current player</param>
			public NavigatorTools(FFACE fface)
			{
				_FFACE = fface;
				HeadingTolerance = 40;
				DistanceTolerance = 3f;
				SpeedDelay = 40;
				StayRunningAmount = 2.5f;
				GotoDelay = 40;

			} // @ public NavigatorTools(PlayerTools player)

			~NavigatorTools()
			{
				if (_IsRunning)
					StopRunning();
			}

			#endregion

			#region Methods

			/// <summary>
			/// Will move the player to the passed destination
			/// </summary>
			/// <param name="x">X coordinate of the destination</param>
			/// <param name="z">Z coordinate of the destination</param>
			/// <param name="KeepRunning">Whether to keep moving after reaching the destination</param>
			public void GotoXZ(dPoint x, dPoint z, bool KeepRunning)
			{
				GotoXYZ(x, () => _FFACE.Player.PosY, z, KeepRunning);
			} // @ public void GotoXZ(dPoint x, dPoint z, bool KeepRunning)

			/// <summary>
			/// Will move the player to the passed destination
			/// </summary>
			/// <param name="x">X coordinate of the destination</param>
			/// <param name="y">Y coordinate of the destination</param>
			/// <param name="z">Z coordinate of the destination</param>
			/// <param name="KeepRunning">Whether to keep moving after reaching the destination</param>
			public void GotoXYZ(dPoint x, dPoint y, dPoint z, bool KeepRunning)
			{
				float X = x();
				float Y = y();
				float Z = z();
				double RH = Math.Abs(HeadingToPosXZ(X, Z) - GetPlayerPosHInDegrees());

				if (GetPlayerPosHInDegrees() > HeadingToPosXZ(X, Z))
					RH = 360 - RH;

				if (RH > 180)
					RH = RH - 360;

				if (_IsRunning)
				{
					// if we're out of our heading tolerance
					if (Math.Abs(RH) > HeadingTolerance * StayRunningAmount)
					{
						// stop moving, and adjust heading
						StopRunning();
						FacePosXZ(X, Z);
					}
					else
						if (Math.Abs(RH) > HeadingTolerance)
							FacePosXZ(X, Z);

				} // @ if (_IsRunning)

				StartRunning();

				// while we're not within our distance tolerance
				while (DistanceToPosXYZ(X, Y, Z) > DistanceTolerance)
				{
					double dist = DistanceToPosXYZ(X, Y, Z);
					X = x();
					Y = y();
					Z = z();
					RH = Math.Abs(HeadingToPosXZ(X, Z) - GetPlayerPosHInDegrees());

					if (GetPlayerPosHInDegrees() > HeadingToPosXZ(X, Z))
						RH = 360 - RH;

					if (RH > 180)
						RH = RH - 360;

					// if we're out of our heading tolerance
					if (Math.Abs(RH) > HeadingTolerance * StayRunningAmount)
					{
						// stop moving and adjust heading
						StopRunning();
						FacePosXZ(X, Z);
						StartRunning();
					}

					if (RH < -HeadingTolerance)
						_FFACE.Windower.SendKeyPress(KeyCode.NP_Number4);
					else if (RH > HeadingTolerance)
						_FFACE.Windower.SendKeyPress(KeyCode.NP_Number6);

					System.Threading.Thread.Sleep(GotoDelay);

				} // @ while (DistanceToPosXZ(X, Z) > DistanceTolerance)

				if (!KeepRunning)
					StopRunning();

			} // @ public void GotoXZ(dPoint x, dPoint y, dPoint z, bool KeepRunning)

			/// <summary>
			/// Will go to the passed NPC's location
			/// </summary>
			/// <param name="ID">ID of the NPC</param>
			public void GotoNPCXZ(short ID)
			{
				GotoXYZ(() => _FFACE.NPC.PosX(ID), () => _FFACE.NPC.PosY(ID), () => _FFACE.NPC.PosZ(ID), false);

			} // @ public void GotoNPCXZ(short ID)

			/// <summary>
			/// Will go to the passed NPC's location
			/// </summary>
			/// <param name="ID">ID of the NPC</param>
			public void GotoNPCXYZ(short ID)
			{
				GotoXYZ(() => _FFACE.NPC.PosX(ID), () => _FFACE.NPC.PosY(ID), () => _FFACE.NPC.PosZ(ID), false);

			} // @ public void GotoNPCXYZ(short ID)

			/// <summary>
			/// Will go to the current target's location
			/// </summary>
			public void GotoTargetXZ()
			{
				GotoXYZ(() => _FFACE.Target.PosX, () => _FFACE.Target.PosY, () => _FFACE.Target.PosZ, false);

			} // @ public void GotoTargetXZ()

			/// <summary>
			/// Will go to the current target's location
			/// </summary>
			public void GotoTargetXYZ()
			{
				GotoXYZ(() => _FFACE.Target.PosX, () => _FFACE.Target.PosY, () => _FFACE.Target.PosZ, false);

			} // @ public void GotoTargetXYZ()

			/// <summary>
			/// Whether we're currently moving or not
			/// </summary>
			public bool IsRunning()
			{
				return _IsRunning;

			} // @ public bool IsRunning()

			/// <summary>
			/// Calculates the distance to the passed destination
			/// </summary>
			/// <param name="X">X coordinate of destination</param>
			/// <param name="Z">Z coordinate of destination</param>
			public double DistanceToPosXZ(double X, double Z)
			{
				//return DistanceToPosXYZ(X, _FFACE.Player.PosY, Z);  Fail since DTPXYZ's Y would == Player.PosY in all cases
				return Math.Sqrt(Math.Pow((_FFACE.Player.PosX - X), 2) + Math.Pow((Z - _FFACE.Player.PosZ), 2));

			} // @ public double DistanceToPosXZ(double X, double Z)

			/// <summary>
			/// Calculates the distance to the passed destination taking height into account.
			/// </summary>
			/// <param name="X">X coordinate of destination</param>
			/// <param name="Y">Y coordinate of destination</param>
			/// <param name="Z">Z coordinate of destination</param>
			public double DistanceToPosXYZ(double X, double Y, double Z)
			{
				return Math.Sqrt(Math.Pow((_FFACE.Player.PosX - X), 2) + Math.Pow((_FFACE.Player.PosY - Y), 2) + Math.Pow((Z - _FFACE.Player.PosZ), 2));

			} // @ public double DistanceToPosXYZ(double X, double Y, double Z)

			/// <summary>
			/// Caulcates the heading to the passed destination
			/// </summary>
			/// <param name="X">X coordinate of destination</param>
			/// <param name="Z">Z coordinate of destination</param>
			public double HeadingToPosXZ(double X, double Z)
			{
				return HeadingToPosXYZ(X, 0, Z);
			} // @ public double HeadingToPosXZ(double X, double Z)

			/// <summary>
			/// Calculates the heading to the passed destination
			/// </summary>
			/// <param name="X">X coordinate of destination</param>
			/// <param name="Y">Y coordinate of destination (not used, here for consistency)</param>
			/// <param name="Z">Z coordinate of destination</param>
			public double HeadingToPosXYZ(double X, double Y, double Z)
			{
				X = X - _FFACE.Player.PosX;
				Z = Z - _FFACE.Player.PosZ;
				double p = 180 * Math.Atan2(X, Z) / Math.PI;

				if (Z < 0)
					return p + 360;
				else
					return p;
			} // @ public double HeadingToPosXYZ(double X, double Y, double Z)

			/// <summary>
			/// Changes facing to passed destination
			/// </summary>
			/// <param name="X">X coordinate of destination</param>
			/// <param name="Z">Z coordinate of destination</param>
			public void FacePosXZ(double X, double Z)
			{
				FaceHeadingXZ(HeadingToPosXYZ(X, 0, Z));
			} // @ public void FacePosXZ(double X, double Z)

			/// <summary>
			/// Changes facing to passed destination
			/// </summary>
			/// <param name="X">X coordinate of destination</param>
			/// <param name="Y">Y coordinate of destination (not used, here for consistency)</param>
			/// <param name="Z">Z coordinate of destination</param>
			public void FacePosXYZ(double X, double Y, double Z)
			{
				FaceHeadingXZ(HeadingToPosXYZ(X, Y, Z));

			} // @ public void FacePosXZ(double X, double Z)

			public void Reset()
			{
				_IsRunning = true;
				StopRunning();

			}

			/// <summary>
			/// Will get the players heading in degrees, and north as 0/360
			/// </summary>
			private double GetPlayerPosHInDegrees()
			{
				double degrees = _FFACE.Player.PosH * (180 / Math.PI) + 90;

				if (degrees > 360)
					degrees -= 360;
				else if (degrees < 0)
					degrees += 360;

				return degrees;

			} // @ private double GetPlayerPosHInDegrees()

			/// <summary>
			/// Will start moving the player to the destination
			/// </summary>
			private void StartRunning()
			{
				if (!_IsRunning)
				{
					_IsRunning = true;
					_FFACE.Windower.SendKey(KeyCode.NP_Number8, true);
					System.Threading.Thread.Sleep(SpeedDelay * 5);

				} // @ if (!_IsRunning)
			} // @ private void StartRunning()

			/// <summary>
			/// Will stop moving the player
			/// </summary>
			private void StopRunning()
			{
				if (_IsRunning)
				{
					_IsRunning = false;
					_FFACE.Windower.SendKey(KeyCode.NP_Number8, false);
					System.Threading.Thread.Sleep(SpeedDelay * 5);

				} // @ if (_IsRunning)
			} // @ private void StopRunning()

			/// <summary>
			/// Changes facing to passed destination
			/// </summary>
			/// <param name="H">The heading to the destination</param>
			private void FaceHeadingXZ(double H)
			{
				FaceHeadingXYZ(H);
			}
			/// <summary>
			/// Changes facing to passed destination (XYZ for consistency)
			/// </summary>
			/// <param name="H">The heading to the destination</param>
			private void FaceHeadingXYZ(double H)
			{
				double RH = 180;

				// if we're moving, stop
				if (_IsRunning)
					StopRunning();

				while (Math.Abs(RH) > HeadingTolerance)
				{
					RH = Math.Abs(H - GetPlayerPosHInDegrees());

					if (GetPlayerPosHInDegrees() > H)
						RH = 360 - RH;

					if (RH > 180)
						RH = RH - 360;

					if (RH < -HeadingTolerance)
					{
						_FFACE.Windower.SendKeyPress(KeyCode.NP_Number4);
						System.Threading.Thread.Sleep(SpeedDelay);
					}
					else if (RH > HeadingTolerance)
					{
						_FFACE.Windower.SendKeyPress(KeyCode.NP_Number6);
						System.Threading.Thread.Sleep(SpeedDelay);
					}

					System.Threading.Thread.Sleep(SpeedDelay);

				} // @ while (Math.Abs(RH) > HeadingTolerance)
			} // @ private void FaceHeadingXYZ(double H)

			#endregion

		} // @ public class NavigatorTools

		//X : E=+ve ; W=-ve
		//Y : Up=-ve ; Down=+ve
		//Z : N=+ve ; S=-ve
		//H : N=0 ; E=90; S=180; W=270

	} // @ public partial class FFACE
}
