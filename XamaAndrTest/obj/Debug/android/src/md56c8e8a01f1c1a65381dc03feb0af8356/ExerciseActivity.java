package md56c8e8a01f1c1a65381dc03feb0af8356;


public class ExerciseActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onStart:()V:GetOnStartHandler\n" +
			"n_onStop:()V:GetOnStopHandler\n" +
			"";
		mono.android.Runtime.register ("XamaAndrTest.ExerciseActivity, XamaAndrTest, Version=1.0.6047.35220, Culture=neutral, PublicKeyToken=null", ExerciseActivity.class, __md_methods);
	}


	public ExerciseActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ExerciseActivity.class)
			mono.android.TypeManager.Activate ("XamaAndrTest.ExerciseActivity, XamaAndrTest, Version=1.0.6047.35220, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public void onStart ()
	{
		n_onStart ();
	}

	private native void n_onStart ();


	public void onStop ()
	{
		n_onStop ();
	}

	private native void n_onStop ();

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
