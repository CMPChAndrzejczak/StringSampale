Imports System.Globalization

Module Module1


    'Write a program that prompts the user to enter b to convert a decimal number to binary and 

    'd to convert a binary number to decimal, and q to quit 

    'B, D and Q in any case should be supported. 

    'if the user chooses to convert to binary, make sure a valid integer is given. 

    'Do not try to convert anything that is not a number 

    'if invalid input is given, report the error and prompt again. 

    'when valid input is given, do the conversion and then print out: 

    '{integer} converted to binary is {binaryStr} 

    'if the user chooses to convert to decimal (from binary), 

    'make sure the string given contains only 0s and 1s. If it contains anything else, report the error 

    'and ask for a new binary string 

    'When a valid string is given print out the conversion as  

    '{binary str} converted to decimal is : {decimal num} 

    'DO NOT HAVE ANY SUBS OR FUNCTIONS WITH MORE THAN 25 LINES 
    Sub main()
        Dim input As String
        Do
            Console.Write("Enter b to convert to binary (base 2), d to convert to base 10, q to quit ->  ")
            input = Console.ReadLine.ToUpper
            If input = "B" Then
                toBinary()
            Else
                input = "D"
                toDecimal()
            End If
        Loop While input.ToUpper() <> "Q"



    End Sub
    Sub toBinary()
        Dim Input As String
        Dim valid As Boolean
        Dim num As Integer
        Dim binstring As String = ""
        Console.Write("Please input a number to be converted to binary. -> ")
        Input = Console.ReadLine.ToUpper
        valid = Integer.TryParse(Input, num)

        While num > 0
            If num Mod 2 = 0 Then
                binstring = "0" & binstring
            Else
                binstring = "1" & binstring
            End If
            num = Math.Floor(num / 2)
        End While
        Console.WriteLine($"{Input} in Binary is {binstring }")
    End Sub
    Sub toDecimal()
        Dim BInput As String
        Dim valid As Boolean
        Dim num As Integer

        Do
            Console.Write("Please input a Binary number to be converted to a number -> ")

            BInput = Console.ReadLine.ToUpper
            valid = isValidBinary(BInput)
            If Not valid Then
                Console.WriteLine("Invalid input")

            Else
                num = convertBinToDec(BInput)

            End If

        Loop While Not valid
        Console.WriteLine($"{BInput} in decimal is {num}")
    End Sub
    Function isValidBinary(str As String) As Boolean
        Dim valid As Boolean = True
        For i As Integer = 0 To str.Length - 1
            If str(i) <> "0" And str(i) <> "1" Then
                valid = False
            End If
        Next
        Return valid
    End Function

    ''' <summary>
    ''' Accepts a string of 1s and 0s and returns the decimal value of it.
    ''' </summary>
    ''' <param name="str"></param>
    ''' <returns></returns>
    Function convertBinToDec(str As String) As Integer
        Dim total As Integer = 0
        '1100
        str = StrReverse(str)
        For i As Integer = 0 To str.Length - 1
            Dim num As Integer
            Integer.TryParse(str(i), num)
            total = total + (num * (2 ^ i))
        Next
        Return total
    End Function
End Module
