package md52a40b73923f373d3b19b019549e07502;


public class SignupActivity
	extends md52a40b73923f373d3b19b019549e07502.BaseActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Etherkeep.Android.SignupActivity, Etherkeep.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", SignupActivity.class, __md_methods);
	}


	public SignupActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == SignupActivity.class)
			mono.android.TypeManager.Activate ("Etherkeep.Android.SignupActivity, Etherkeep.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
