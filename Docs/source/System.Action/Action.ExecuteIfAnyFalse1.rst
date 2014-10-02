ExecuteIfAnyFalse 1
===================

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

**Exceptions**

| `System.ArgumentNullException <http://msdn.microsoft.com/en-us/library/system.ArgumentNullException/>`_
|     False action can not be null, if any of the values is false.

**Example**

.. sourcecode:: csharp

    Action falseAction = () => Console.WriteLine("False Action");
    Action trueAction = () => Console.WriteLine("True Action");
    
    falseAction.ExecuteIfAnyFalse(trueAction, false, true, true);
    falseAction.ExecuteIfAnyFalse(false);
    falseAction.ExecuteIfAnyFalse(trueAction, true, true);
    
    /*
     * The example displays the following output to the console: 
     * False Action
     * False Action
     * True Action
     */

----

Executes the specified action if one of the given Boolean values is false, otherwise it executes the specified true action, if one is specified.

.. sourcecode:: csharp

     public static void ExecuteIfAnyFalse<T>(
         this Action<T> falseAction,
         T parameter,
         Action<T> trueAction,
         params Boolean[] values 
    )

**Parameters**

| *falseAction*
|     Type: `System.Action <http://msdn.microsoft.com/en-us/library/system.action/>`_
|     The action to execute if any of the given values is false.

| *parameter*
|     Type: T
|     The parameter to pass to the action with gets executed.

| *trueAction*
|     Type: `System.Action <http://msdn.microsoft.com/en-us/library/system.action/>`_
|     The action to execute if all values are true.

| *values*
|     Type: `System.Object[] <http://msdn.microsoft.com/en-us/library/system.object/>`_
|     The Boolean values to check.

**Exceptions**

| `System.ArgumentNullException <http://msdn.microsoft.com/en-us/library/system.ArgumentNullException/>`_
|     False action can not be null, if any of the values is false.

.. sourcecode:: csharp

    Action falseAction = () => Console.WriteLine("False Action");
    Action trueAction = () => Console.WriteLine("True Action");
    
    falseAction.ExecuteIfAnyFalse(trueAction, false, true, true);
    falseAction.ExecuteIfAnyFalse(false);
    falseAction.ExecuteIfAnyFalse(trueAction, true, true);
    
    /*
     * The example displays the following output to the console: 
     * False Action
     * False Action
     * True Action
     */

----

Executes the specified action if one of the given Boolean values is false, otherwise it executes the specified true action, if one is specified.

.. sourcecode:: csharp

     public static void ExecuteIfAnyFalse<T>(
         this Action<T> falseAction,
         T parameter,
         Action<T> trueAction,
         params Boolean[] values 
    )

**Parameters**

| *falseAction*
|     Type: `System.Action <http://msdn.microsoft.com/en-us/library/system.action/>`_
|     The action to execute if any of the given values is false.

| *parameter*
|     Type: T
|     The parameter to pass to the action with gets executed.

| *trueAction*
|     Type: `System.Action <http://msdn.microsoft.com/en-us/library/system.action/>`_
|     The action to execute if all values are true.

| *values*
|     Type: `System.Object[] <http://msdn.microsoft.com/en-us/library/system.object/>`_
|     The Boolean values to check.

**Exceptions**

| `System.ArgumentNullException <http://msdn.microsoft.com/en-us/library/system.ArgumentNullException/>`_
|     False action can not be null, if any of the values is false.

.. sourcecode:: csharp

    Action falseAction = () => Console.WriteLine("False Action");
    Action trueAction = () => Console.WriteLine("True Action");
    
    falseAction.ExecuteIfAnyFalse(trueAction, false, true, true);
    falseAction.ExecuteIfAnyFalse(false);
    falseAction.ExecuteIfAnyFalse(trueAction, true, true);
    
    /*
     * The example displays the following output to the console: 
     * False Action
     * False Action
     * True Action
     */

----

Executes the specified action if one of the given Boolean values is false, otherwise it executes the specified true action, if one is specified.

.. sourcecode:: csharp

     public static void ExecuteIfAnyFalse<T>(
         this Action<T> falseAction,
         T parameter,
         Action<T> trueAction,
         params Boolean[] values 
    )

**Parameters**

| *falseAction*
|     Type: `System.Action <http://msdn.microsoft.com/en-us/library/system.action/>`_
|     The action to execute if any of the given values is false.

| *parameter*
|     Type: T
|     The parameter to pass to the action with gets executed.

| *trueAction*
|     Type: `System.Action <http://msdn.microsoft.com/en-us/library/system.action/>`_
|     The action to execute if all values are true.

| *values*
|     Type: `System.Object[] <http://msdn.microsoft.com/en-us/library/system.object/>`_
|     The Boolean values to check.

**Exceptions**

| `System.ArgumentNullException <http://msdn.microsoft.com/en-us/library/system.ArgumentNullException/>`_
|     False action can not be null, if any of the values is false.

.. sourcecode:: csharp

    Action falseAction = () => Console.WriteLine("False Action");
    Action trueAction = () => Console.WriteLine("True Action");
    
    falseAction.ExecuteIfAnyFalse(trueAction, false, true, true);
    falseAction.ExecuteIfAnyFalse(false);
    falseAction.ExecuteIfAnyFalse(trueAction, true, true);
    
    /*
     * The example displays the following output to the console: 
     * False Action
     * False Action
     * True Action
     */

----