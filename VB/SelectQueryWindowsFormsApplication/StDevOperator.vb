Imports System
Imports System.Collections.Generic
Imports DevExpress.Data.Filtering


Namespace SelectQueryWindowsFormsApplication
    Public NotInheritable Class StDevOperator
        Implements ICustomFunctionOperatorBrowsable, ICustomFunctionOperatorFormattable
        Private Const name_Renamed As String = "StDev"
        Public Shared Sub Register()
            CriteriaOperator.RegisterCustomFunction(New StDevOperator())
        End Sub
        Public Shared Sub Unregister()
            CriteriaOperator.UnregisterCustomFunction(name_Renamed)
        End Sub
        Public Shared ReadOnly ValidOperandTypes As New HashSet(Of Type)() From {GetType(SByte), GetType(Byte), GetType(Short), GetType(UShort), GetType(Integer), GetType(UInteger), GetType(Long), GetType(ULong), GetType(Decimal), GetType(Double), GetType(Single)}

#Region "ICustomFunctionOperator"
        Public Function ResultType(ParamArray ByVal operands() As Type) As Type Implements ICustomFunctionOperator.ResultType
            Return GetType(Double)
        End Function
        Public Function Evaluate(ParamArray ByVal operands() As Object) As Object Implements ICustomFunctionOperator.Evaluate
            Throw New NotSupportedException()
        End Function
        Public ReadOnly Property Name() As String Implements ICustomFunctionOperator.Name
            Get
                Return name_Renamed
            End Get
        End Property

#End Region
#Region "ICustomFunctionOperatorBrowsable"
        Public ReadOnly Property Category() As FunctionCategory Implements ICustomFunctionOperatorBrowsable.Category
            Get
                Return FunctionCategory.Math
            End Get
        End Property
        Public ReadOnly Property Description() As String Implements ICustomFunctionOperatorBrowsable.Description
            Get
                Return "Standard deviation function"
            End Get
        End Property
        Public Function IsValidOperandCount(ByVal count As Integer) As Boolean Implements ICustomFunctionOperatorBrowsable.IsValidOperandCount
            Return count = 1
        End Function
        Public Function IsValidOperandType(ByVal operandIndex As Integer, ByVal operandCount As Integer, ByVal type As Type) As Boolean Implements ICustomFunctionOperatorBrowsable.IsValidOperandType
            Return ValidOperandTypes.Contains(type)
        End Function
        Public ReadOnly Property MaxOperandCount() As Integer Implements ICustomFunctionOperatorBrowsable.MaxOperandCount
            Get
                Return 1
            End Get
        End Property
        Public ReadOnly Property MinOperandCount() As Integer Implements ICustomFunctionOperatorBrowsable.MinOperandCount
            Get
                Return 1
            End Get
        End Property
#End Region

#Region "ICustomFunctionOperatorFormattable"
        Public Function Format(ByVal providerType As Type, ParamArray ByVal operands() As String) As String Implements ICustomFunctionOperatorFormattable.Format
            Return String.Format("stdev({0})", operands(0))
        End Function
#End Region
    End Class
End Namespace
