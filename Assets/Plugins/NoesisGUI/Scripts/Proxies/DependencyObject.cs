/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 2.0.4
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */


using System;
using System.Runtime.InteropServices;

namespace Noesis
{

public partial class DependencyObject : BaseComponent {
  internal new static DependencyObject CreateProxy(IntPtr cPtr, bool cMemoryOwn) {
    return new DependencyObject(cPtr, cMemoryOwn);
  }

  internal DependencyObject(IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn) {
  }

  internal static HandleRef getCPtr(DependencyObject obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  protected DependencyObject() {
  }

  public void InvalidateProperty(DependencyProperty dp) {
    InvalidatePropertyHelper(dp);
  }

  public void ClearValue(DependencyProperty dp) {
    NoesisGUI_PINVOKE.DependencyObject_ClearValue(swigCPtr, DependencyProperty.getCPtr(dp));
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
  }

  public void ClearAnimation(DependencyProperty dp) {
    NoesisGUI_PINVOKE.DependencyObject_ClearAnimation(swigCPtr, DependencyProperty.getCPtr(dp));
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
  }

  public void CoerceValue(DependencyProperty dp) {
    NoesisGUI_PINVOKE.DependencyObject_CoerceValue(swigCPtr, DependencyProperty.getCPtr(dp));
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
  }

  new internal static IntPtr GetStaticType() {
    IntPtr ret = NoesisGUI_PINVOKE.DependencyObject_GetStaticType();
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return ret;
  }

  public object ReadLocalValue(DependencyProperty dp) {
    IntPtr cPtr = NoesisGUI_PINVOKE.DependencyObject_ReadLocalValue(swigCPtr, DependencyProperty.getCPtr(dp));
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return Noesis.Extend.GetProxy(cPtr, false);
  }

  public void SetCurrentValue(DependencyProperty dp, object value) {
    NoesisGUI_PINVOKE.DependencyObject_SetCurrentValue(swigCPtr, DependencyProperty.getCPtr(dp), Noesis.Extend.GetInstanceHandle(value));
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
  }

  internal void InitObject() {
    NoesisGUI_PINVOKE.DependencyObject_InitObject(swigCPtr);
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
  }

  private void InvalidatePropertyHelper(DependencyProperty dp) {
    NoesisGUI_PINVOKE.DependencyObject_InvalidatePropertyHelper(swigCPtr, DependencyProperty.getCPtr(dp));
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
  }


  internal new static IntPtr Extend(string typeName) {
    IntPtr nativeType = NoesisGUI_PINVOKE.Extend_DependencyObject(Marshal.StringToHGlobalAnsi(typeName));
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return nativeType;
  }
}

}

