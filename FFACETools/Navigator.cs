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

			public void SetViewMode(ViewMode newMode)
			{
				if (_FFACE.Player.ViewMode != newMode)
				{
					_FFACE.Windower.SendKeyPress(KeyCode.NP_Number5);
					System.Threading.Thread.Sleep(SpeedDelay);
				}
			}

			/// <summary>
			/// Will move the player to the passed destination
			/// </summary>
			/// <param name="x">X coordinate of the destination</param>
			/// <param name="z">Z coordinate of the destination</param>
			/// <param name="KeepRunning">Whether to keep moving after reaching the destination</param>
			public void GotoXZ(dPoint x, dPoint z, bool KeepRunning)
			{
				GotoXYZ(x, () => _FFACE.Player.PosY, z, KeepRunning, -1);
			} // @ public void GotoXZ(dPoint x, dPoint z, bool KeepRunning)

			/// <summary>
			/// Will move the player to the passed destination
			/// </summary>
			/// <param name="x">X coordinate of the destination</param>
			/// <param name="z">Z coordinate of the destination</param>
			/// <param name="KeepRunning">Whether to keep moving after reaching the destination</param>
			public void GotoXZ(dPoint x, dPoint z, bool KeepRunning, int timeOut)
			{
				GotoXYZ(x, () => _FFACE.Player.PosY, z, KeepRunning, timeOut);
			}

			/// <summary>
			/// Will move the player to the passed destination
			/// </summary>
			/// <param name="x">X coordinate of the destination</param>
			/// <param name="y">Y coordinate of the destination</param>
			/// <param name="z">Z coordinate of the destination</param>
			/// <param name="KeepRunning">Whether to keep moving after reaching the destination</param>
			public void GotoXYZ(dPoint x, dPoint y, dPoint z, bool KeepRunning)
			{
				GotoXYZ(x, y, z, KeepRunning, -1);
			}


			public bool SetPlayerDegrees(double degrees)
			{
				if (degrees < 0 || degrees > 360)
				{
					return false;
				}
				if (FFACE.SetNPCPosH(_FFACE._InstanceID, _FFACE.Player.ID, ConvertDegreesToPosH(degrees)) != 0.0f)
					return true;
				return false;
			}

			private bool SetNPCDegrees(int index, double degrees)
			{
				if (degrees < 0 || degrees > 360)
				{
					return false;
				}
				if (FFACE.SetNPCPosH(_FFACE._InstanceID, index, ConvertDegreesToPosH(degrees)) != 0.0f)
					return true;
				return false;
			}

			public void SetPlayerPosH(float value)
			{
				FFACE.SetNPCPosH(_FFACE._InstanceID, _FFACE.Player.ID, value);
			}

			private void SetNPCPosH(int index, float value)
			{
				FFACE.SetNPCPosH(_FFACE._InstanceID, index, value);
			}

			/// <summary>
			/// Will move the player to the passed destination
			/// </summary>
			/// <param name="x">X coordinate of the destination</param>
			/// <param name="y">Y coordinate of the destination</param>
			/// <param name="z">Z coordinate of the destination</param>
			/// <param name="KeepRunning">Whether to keep moving after reaching the destination</param>
			public void GotoXYZ(dPoint x, dPoint y, dPoint z, bool KeepRunning, int timeOut)
			{
				float X = x();
				float Y = y();
				float Z = z();
				double RH = Math.Abs(HeadingToPosXZ(X, Z) - GetPlayerPosHInDegrees());

				if (GetPlayerPosHInDegrees() > HeadingToPosXZ(X, Z))
					RH = 360 - RH;

				if (RH > 180)
					RH = RH - 360;

				SetViewMode(ViewMode.FirstPerson);
				if (_IsRunning)
				{
					// if we're out of our heading tolerance
					if (Math.Abs(RH) > HeadingTolerance * StayRunningAmount)
					{
						SetPlayerDegrees(HeadingToPosXYZ(X, Y, Z));
						// stop moving, and adjust heading
						/* OLD Way
						StopRunning();
						FacePosXZ(X, Z);
						 */
					}
				} // @ if (_IsRunning)
				else if (Math.Abs(RH) > HeadingTolerance)
				{
					SetPlayerDegrees(HeadingToPosXYZ(X, Y, Z));
					/* OLD WAY
					 FacePosXZ(X, Z);
					 */
				}


				DateTime Now = DateTime.Now;

				StartRunning();

				// while we're not within our distance tolerance
				while ((DistanceToPosXYZ(X, Y, Z) > DistanceTolerance) &&
					((timeOut <= 0) || ((timeOut > 0) && ((DateTime.Now - Now).TotalMilliseconds) < timeOut)))
				{
					SetViewMode(ViewMode.FirstPerson);
					double dist = DistanceToPosXYZ(X, Y, Z);
					X = x();
					Y = y();
					Z = z();

					RH = Math.Abs(HeadingToPosXZ(X, Z) - GetPlayerPosHInDegrees());

					if (GetPlayerPosHInDegrees() > HeadingToPosXZ(X, Z))
						RH = 360 - RH;

					if (RH > 180)
						RH = RH - 360;

					//double calcTolerance = Math.Abs(dist - (HeadingTolerance * StayRunningAmount));

					// if we're out of our heading tolerance
					if (Math.Abs(RH) > HeadingTolerance * StayRunningAmount) // calcTolerance) 
					{
						// stop moving and adjust heading
						/*StopRunning();
						FacePosXZ(X, Z);
						StartRunning();*/
						SetPlayerDegrees(HeadingToPosXYZ(X, Y, Z));
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
				GotoXYZ(() => _FFACE.NPC.PosX(ID), () => _FFACE.NPC.PosY(ID), () => _FFACE.NPC.PosZ(ID), false, -1);

			} // @ public void GotoNPCXZ(short ID)

			/// <summary>
			/// Will go to the passed NPC's location
			/// </summary>
			/// <param name="ID">ID of the NPC</param>
			public void GotoNPCXZ(short ID, int timeOut)
			{
				GotoXYZ(() => _FFACE.NPC.PosX(ID), () => _FFACE.NPC.PosY(ID), () => _FFACE.NPC.PosZ(ID), false, timeOut);
			}
			
			/// <summary>
			/// Will go to the passed NPC's location
			/// </summary>
			/// <param name="ID">ID of the NPC</param>
			public void GotoNPCXYZ(short ID, int timeOut)
			{
				GotoXYZ(() => _FFACE.NPC.PosX(ID), () => _FFACE.NPC.PosY(ID), () => _FFACE.NPC.PosZ(ID), false, timeOut);
			}
			
			/// <summary>
			/// Will go to the passed NPC's location
			/// </summary>
			/// <param name="ID">ID of the NPC</param>
			public void GotoNPCXYZ(short ID)
			{
				GotoXYZ(() => _FFACE.NPC.PosX(ID), () => _FFACE.NPC.PosY(ID), () => _FFACE.NPC.PosZ(ID), false, -1);

			} // @ public void GotoNPCXYZ(short ID)

			/// <summary>
			/// Will go to the current target's location
			/// </summary>
			public void GotoTargetXZ()
			{
				GotoXYZ(() => _FFACE.Target.PosX, () => _FFACE.Target.PosY, () => _FFACE.Target.PosZ, false, -1);

			} // @ public void GotoTargetXZ()

			/// <summary>
			/// Will go to the current target's location
			/// </summary>
			public void GotoTargetXZ(int timeOut)
			{
				GotoXYZ(() => _FFACE.Target.PosX, () => _FFACE.Target.PosY, () => _FFACE.Target.PosZ, false, timeOut);
			}
			
			/// <summary>
			/// Will go to the current target's location
			/// </summary>
			public void GotoTargetXYZ()
			{
				GotoXYZ(() => _FFACE.Target.PosX, () => _FFACE.Target.PosY, () => _FFACE.Target.PosZ, false, -1);

			} // @ public void GotoTargetXYZ()

			/// <summary>
			/// Will go to the current target's location
			/// </summary>
			public void GotoTargetXYZ(int timeOut)
			{
				GotoXYZ(() => _FFACE.Target.PosX, () => _FFACE.Target.PosY, () => _FFACE.Target.PosZ, false, timeOut);
			}
			
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
				return GetPosHInDegrees(_FFACE.Player.PosH);
			} // @ private double GetPlayerPosHInDegrees()

			/// <summary>
			/// Will get the heading in degrees, and north as 0/360
			/// </summary>
			public double GetPosHInDegrees(float PosH)
			{
				double degrees = PosH * (180 / Math.PI) + 90;

				if (degrees >= 360)
					degrees -= 360;
				else if (degrees < 0)
					degrees += 360;

				return degrees;

			} // @ private double GetPlayerPosHInDegrees()

			public float ConvertDegreesToPosH(double Degrees)
			{
				// Normal Radians			FFXI Radians			Turns
				//		N 0/2Pi					N -Pi/2				N  0 or Turn
				//	W Pi/2	E 3Pi/2			W -Pi/Pi	E 0		W Turn/4	E 3Turn/4
				//		S Pi					S Pi/2				S Turn/2

				double degrees = Degrees;
				float PosH;
				degrees = degrees + 90;
				if (degrees > 360)
					degrees -= 360;
				else if (degrees < 0)
					degrees += 360;
				PosH = ((float)(((degrees * Math.PI) / 180.0f)) - (float)Math.PI);
				//if (PosH > (2*Math.PI))
				//{
				//    PosH -= (float)(2*Math.PI);
				//}
				//else if (PosH < -(2*Math.PI))
				//{
				//    PosH += (float)(2*Math.PI);
				//}
				// 359 degrees = -Pi/2   0 = -Pi/2
				// 
				return PosH;
			}

			/// <summary>
			/// Will start moving the player to the destination
			/// </summary>
			private void StartRunning()
			{
				if (!_IsRunning)
				{
					_IsRunning = true;
					_FFACE.Windower.SendKey(KeyCode.NP_Number8, true);
					System.Threading.Thread.Sleep(SpeedDelay);

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
					System.Threading.Thread.Sleep(SpeedDelay);

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
					}
					else if (RH > HeadingTolerance)
					{
						_FFACE.Windower.SendKeyPress(KeyCode.NP_Number6);
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
