ExecuteIfAnyFalse
=================

Executes the specified action if one of the given Boolean values is false, otherwise it executes the specified true action, if one is specified.

.. sourcecode:: csharp
 
    public static void ExecuteIfAnyFalse( 
        this Action falseAction, 
        Action trueAction, 
        params Boolean[] values 
    )

**Parameters**

| *falseAction*
|     Type: `System.Action <http://msdn.microsoft.com/en-us/library/system.action/>`_
|     The action to execute if any of the given values is false.

| *trueAction*
|     Type: `System.Action <http://msdn.microsoft.com/en-us/library/system.action/>`_
|     The action to execute if all values are true.

| *values*
|     Type: `System.Object[] <http://msdn.microsoft.com/en-us/library/system.object/>`_
|     The Boolean values to check.