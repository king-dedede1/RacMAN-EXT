-- for writing output to the Console
-- maybe deprecated?

Console = {}

Console.Log = function(text)
    Racman:Log(text)
end

-- set print as alias for Console.Log for backwards compatibility i guess
print = Console.Log

Console.Warn = function(text)
    Racman:Warn(text)
end

Console.Error = function(text)
    Racman:Error(text)
end

Console.Clear = function()
    --Racman.consoleForm.Controls[2].Text = ""
    -- removed becuase not thread safe
end