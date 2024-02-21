-- Utility class for converting data to and from byte arrays, and byte arrays to and from tables.

-- this is stupid but theres a .net class called convert so importing it breaks everything


import('System','System')


require 'Console'

if BitConverter == nil then
	Console.Error('Could not import BitConverter!!!')
end

--[[
defined by c# code:
TableToByteArray(table) -- convert lua table to c# byte array
IntToByteArray(bytes, width) -- convert int (any width) to c# byte array
FloatToByteArray(float) -- convert float to c# byte array.
ReverseArray(array) -- put a c# array in reverse order
]]

if Convert == nil then
	Convert = {}
end

-- converts a c# array into a table
-- stolen from stackoverflow
Convert.ArrayToTable = function(array)
	local t = {}
	local it = array:GetEnumerator()
	while it:MoveNext() do
		t[#t+1] = it.Current
	end
	return t
end

-- Converts a C# byte array into a number
-- can be any width, 8 16 32 or 64 bit.
Convert.ByteArrayToInt = function(bytes)
	bytes = Convert.ReverseArray(bytes)
	if bytes.Length == 8 then
		return BitConverter.ToUInt64(bytes,0)
	elseif bytes.Length == 4 then
		return BitConverter.ToUInt32(bytes,0)
	elseif bytes.Length == 2 then
		return BitConverter.ToUint16(bytes,0)
	elseif bytes.Length == 1 then
		return bytes[0] -- no idea if this works.
	else
		Console.Error('ByteArrayToInt: Invalid array size')
	end
end

Convert.ByteArrayToFloat = function(bytes)
	if bytes.Length == 4 then
		return BitConverter.ToSingle(bytes,0)
	elseif bytes.Length == 8 then
		return BitConverter.ToDouble(bytes,0)
	else
		Console.Error('ByteArrayToFloat: Invalid array size')
	end
end
