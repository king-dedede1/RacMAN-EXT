import('System.Windows.Forms','System.Windows.Forms')

Timing = {}

--[[ this is kinda unsafe because if a lua exception is thrown on the
function thats passed in the whole program crashes for some reason ]]
Timing.DoLater = function(func, delay_ms)
    local timer = Timer()
    timer.Tick:Add(function(sender, e)
        func()
        timer:Stop()
    end)
    timer.Interval = delay_ms
    timer:Start()
end
