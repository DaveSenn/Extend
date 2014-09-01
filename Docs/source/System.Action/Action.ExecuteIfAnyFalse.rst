ExecuteIfAnyFalse
=================

Executes the specified action if one of the given Boolean values is false, otherwise it executes the specified true action, if one is specified.

.. sourcecode:: csharp
 
    public static void ExecuteIfAnyFalse( 
      this Action falseAction, 
      Action trueAction, 
      params Boolean[] values 
    )

Parameters
