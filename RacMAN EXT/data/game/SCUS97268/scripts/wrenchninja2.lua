ADDR_COUNTER = 0x1AED04
ADDR_FLAG = 0x1AED00

local callback1 = function(bytes)
    Trainer.GetControlByName('wn2counter').Text = "Counter: " .. Convert.ByteArrayToInt(bytes)
end

local callback2 = function(bytes)
    Trainer.GetControlByName('wn2flag').Text = "Flag: " .. Convert.ByteArrayToInt(bytes)
end


local subid1 = nil
local subid2 = nil
function startWn2MemorySubs()
    subid1 = API:SubMemory(ADDR_COUNTER, 4, callback1)
    subid2 = API:SubMemory(ADDR_FLAG, 4, callback2)
end

function stopWn2MemorySubs()
    API:ReleaseSubID(subid1)
    API:ReleaseSubID(subid2)
    Trainer.GetControlByName('wn2counter').Text = "N/A"
    Trainer.GetControlByName('wn2flag').Text = "N/A"
end