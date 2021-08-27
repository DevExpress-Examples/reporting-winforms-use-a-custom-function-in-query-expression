<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128603765/16.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T352441)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/SelectQueryWindowsFormsApplication/Form1.cs) (VB: [Form1.vb](./VB/SelectQueryWindowsFormsApplication/Form1.vb))
* [StDevOperator.cs](./CS/SelectQueryWindowsFormsApplication/StDevOperator.cs) (VB: [StDevOperator.vb](./VB/SelectQueryWindowsFormsApplication/StDevOperator.vb))
<!-- default file list end -->
# How to use a custom function in a query expression


<p>This example illustrates how to use a custom aggregate function in a SELECT query.</p>
<p>In this example, the created custom function estimates the standard deviation (similar to the “stdev” function available in Microsoft SQL).</p>
<p>To provide this functionality, do the following.</p>
<p>1. Implement a custom aggregate function.</p>
<p>A custom function must implement the following interfaces (all belonging to the <a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressDataFiltering">DevExpress.Data.Filtering</a> namespace): <a href="https://documentation.devexpress.com/#CoreLibraries/clsDevExpressDataFilteringICustomFunctionOperatortopic">ICustomFunctionOperator</a>, <a href="https://documentation.devexpress.com/#CoreLibraries/clsDevExpressDataFilteringICustomFunctionOperatorBrowsabletopic">ICustomFunctionOperatorBrowsable</a>, and <a href="https://documentation.devexpress.com/#CoreLibraries/clsDevExpressDataFilteringICustomFunctionOperatorFormattabletopic">ICustomFunctionOperatorFormattable</a>.</p>
<p>These interfaces provide the following main properties:</p>
<p><strong>ICustomFunctionOperator</strong>:</p>
<p><strong>- ResultType</strong> – specifies the type of a result corresponding to the input data of a specific type;</p>
<p><strong>- Name</strong> – the name of a function, by which it can be addressed later on.</p>
<p><strong>ICustomFunctionOperatorBrowsable</strong>:</p>
<p><strong>- Category</strong> – the type of a function (logical, string, or math);</p>
<p><strong>- Description</strong> – a short text description of the function;</p>
<p><strong>- IsValidOperandCount</strong> – indicates whether or not calling this function with a specific number of parameters is allowed;</p>
<p><strong>- IsValidOperandType</strong> – indicates whether or not a parameter supports the specific type (i.e., for the parameter with the specified <strong>operandIndex</strong> from <strong>operandCount</strong>);</p>
<p><strong>- MaxOperandCount</strong> – specifies the maximum allowed number of parameters;</p>
<p><strong>- MinOperandCount</strong> – specifies the minimum allowed number of parameters;</p>
<p><strong>ICustomFunctionOperatorFormattable</strong>:</p>
<p><strong>- Format</strong> – specifies how to construct an SQL string corresponding to this function (the <strong>providerType</strong> parameter allows you to determine the type of a connected server and generate appropriate strings for different dialects of SQL. In this example, this option is omitted, as the data source type is known beforehand).</p>
<p> </p>
<p>2. Register this function.</p>
<p>To register custom functions in this example, the static <a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressDataFilteringCriteriaOperator_RegisterCustomFunctiontopic">RegisterCustomFunction</a> method of the <a href="https://documentation.devexpress.com/#CoreLibraries/clsDevExpressDataFilteringCriteriaOperatortopic">CriteriaOperator</a> class is used.</p>
<p>For convenience, the custom function that has been created in the previous step implements the static <strong>Register</strong> method that registers the function. This method should be called before using the function for the first time (e.g., at the application launch). It does not matter if, for any reason, this method is called once again later on.</p>
<p> </p>
<p>3. Use this function.</p>
<p>As the function has been registered, it can be used as a part of an SQL expression and becomes listed in the query editor among other functions.<br><br>See also: <a href="https://www.devexpress.com/Support/Center/p/T211298">Expression Editor - How to implement a custom New Line and Format functions</a>.</p>

<br/>


