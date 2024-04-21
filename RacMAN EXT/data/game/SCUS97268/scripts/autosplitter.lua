local current, old
current = {}
old = {}

local longLoadTimes = {
    3.6, -- right to left
    3.7, -- top right corner
    3.6, -- left to right
    4.0, -- top down
    0    -- planet
}

-- subscribing to memory instead of reading every frame has no performance benefit on emu
local function updateValues()

    -- shallow copy current to old
    for k, v in pairs(current) do
        old[k] = v
    end

    -- read memory and store in current
    current.planet = Memory.ReadInt(0x1a79f0)
    current.dest = Memory.ReadInt(0x139410) -- temporary
    current.gamestate = Memory.ReadInt(0x1a8f00)
    current.loadingScreenCount = Memory.ReadInt(0x152c68)
    current.loadingScreenID = Memory.ReadInt(0x152c64)
    current.blackscreen = Memory.ReadByte(0x18C0E1)

end

local function start()
    -- called when autosplitter is started.
    print('Rac2 autosplitter starting')


end

local function update(timer)

    updateValues()

    -- planet split
    if current.dest ~= old.dest then
        timer:Split()
        print('Splitting')
    end

    -- long load removal
    -- if the third load screen you get isn't the last one, remove time
    if current.loadingScreenCount == 2 and old.loadingScreenCount ~= 2 and current.loadingScreenID ~= 4 then
        timer:DoCommand('addloadingtimes '.. tostring(longLoadTimes[current.loadingScreenID + 1]))
        print('Removing long load ('..tostring(longLoadTimes[current.loadingScreenID + 1])..' seconds)')
    end

    if current.blackscreen == 1 and old.blackscreen == 0 then
        timer:DoCommand('pausegametime')
        print('Pausing game time for blackscreen')
    end

    if current.blackscreen == 0 and old.blackscreen == 1 then
        timer:DoCommand('unpausegametime')
        print('Unpausing game time for blackscreen')
    end
end

local function stop()
    -- called when autosplitter is stopped.
    print('Stopping autosplitter')
end

Autosplitter.Create("Rac2 Autosplitter", "Splits on planet change and removes long loads.", start, update, stop)