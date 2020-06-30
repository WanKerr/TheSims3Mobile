// Decompiled with JetBrains decompiler
// Type: Accelerometer
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

//using Microsoft.Devices.Sensors;
using Microsoft.Xna.Framework;
using System;

internal class Accelerometer
{
  private static Accelerometer m_accelerometer;
  private Vector3 reading;
  private Vector3 lastReading;
  //private Accelerometer accelerometer;

  public Accelerometer()
  {
    //this.accelerometer = new Accelerometer();
    //this.accelerometer.add_ReadingChanged(new EventHandler<AccelerometerReadingEventArgs>(this.accelerometer_ReadingChanged));
    //this.reading = Vector3.Zero;
    //this.lastReading = Vector3.Zero;
    //try
    //{
    //  this.accelerometer.Start();
    //}
    //catch (AccelerometerFailedException ex)
    //{
    //}
  }

  //private void accelerometer_ReadingChanged(object sender, AccelerometerReadingEventArgs e)
  //{
  //  this.lastReading = this.reading;
  //  this.reading.X = (float) e.get_X();
  //  this.reading.Y = (float) e.get_Y();
  //  this.reading.Z = (float) e.get_Z();
  //}

  public static Accelerometer getStaticAccelerometer()
  {
    if (Accelerometer.m_accelerometer == null)
      Accelerometer.m_accelerometer = new Accelerometer();
    return Accelerometer.m_accelerometer;
  }

  public void accelerate(float ax, float ay, float az)
  {
    throw new NotImplementedException();
  }

  public void setFilterFactor(float factor)
  {
    throw new NotImplementedException();
  }

  public bool getRoll(ref float dest)
  {
    dest = 90f - (float) (-(double) this.reading.Y * 90.0);
    return true;
  }

  public bool getInstantRoll(ref float dest)
  {
    dest = this.reading.Y - this.lastReading.Y;
    return true;
  }

  public bool getPitch(ref float dest)
  {
    midp.JSystem.println("TODO: implement getPitch() in Accelerometer");
    return false;
  }

  public bool getInstantPitch(ref float dest)
  {
    midp.JSystem.println("TODO: implement getInstantPitch() in Accelerometer");
    return false;
  }

  public void getXYZ(ref float x, ref float y, ref float z)
  {
    x = this.reading.X;
    y = this.reading.Y;
    z = this.reading.Z;
  }

  public void getRawXYZ(ref float x, ref float y, ref float z)
  {
    x = this.reading.X;
    y = this.reading.Y;
    z = this.reading.Z;
  }
}
