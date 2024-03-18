-- for writing output to the Console

Console = {}

Console.Log = function(text)
    Racman.consoleForm:Log(text)
end

-- set print as alias for Console.Log for backwards compatibility i guess
print = Console.Log

Console.Warn = function(text)
    Racman.consoleForm:Warn(text)
end

Console.Error = function(text)
    Racman.consoleForm:Error(text)
end

Console.Clear = function()
    Racman.consoleForm.Controls[2].Text = ""
end