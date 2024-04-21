require 'address'

rac2 = {}

rac2.vars = {
    bolts = {
        address = ADDR_BOLTS,
        size = 4,
        type = "int"
    },
    raritanium = {
        address = ADDR_RARITANIUM,
        size = 4,
        type = "int"
    },
    health = {
        address = ADDR_PLAYER_HEALTH,
        size = 4,
        type = "int"
    },
    max_health = {
        address = ADDR_MAX_HEALTH,
        size = 4,
        type = "int"
    },
    challenge_mode = {
        address = ADDR_CHALLENGE_MODE,
        size = 1,
        type = "int"
    },
    xp_economy = {
        address = ADDR_XP_ECONOMY,
        size = 4,
        type = 'int'
    },
    bolt_economy = {
        address = ADDR_BOLT_ECONOMY,
        size = 4,
        type = 'int'
    },
    armor = {
        address = ADDR_ARMOR,
        size = 1, 
        -- its actually 2 bytes but I havent bothered to implement a WriteShort yet
        type = 'int'
    },
    tabora_crystals = {
        address = ADDR_CRYSTALS,
        size = 1, -- actually 2 again
        type = 'int'
    },
    player_x = {
        address = ADDR_PLAYER_POS_X,
        size = 4,
        type = 'float'
    },
    player_y = {
        address = ADDR_PLAYER_POS_Y,
        size = 4,
        type = 'float'
    },
    player_z = {
        address = ADDR_PLAYER_POS_Z,
        size = 4,
        type = 'float'
    }
}

metatable = {}

metatable.__index = function(table, key)
    if table.vars[key] ~= nil then
        local ptr = table.vars[key]
        if ptr.address == nil then
            Console.Warn('Var ' .. key.. ' has nil address!!')
            return
        end
        if ptr.type == 'int' then
            return Convert.ByteArrayToInt(API:ReadMemory(ptr.address, ptr.size),false)
        elseif ptr.type == 'float' then
            return Memory.ReadFloat(ptr.address)
        else
            Console.Warn('Pointer'.. key ..' has unknown type')
        end
    else
        return nil
    end
end

metatable.__newindex = function(table, key, value)
    if table.vars[key] ~= nil then
        local ptr = table.vars[key]
        if ptr.address == nil then
            Console.Warn('Var ' .. key.. ' has nil address!!')
            return
        end
        if ptr.type == 'int' then
            API:WriteMemory(ptr.address, Convert.IntToByteArray(value, ptr.size, false))
        elseif ptr.type == 'float' then
            Memory.WriteFloat(ptr.address, value)
        else
            Console.Warn('Pointer ' .. key .. ' has unknown type')
        end
    else
        rawset(table, key, value)
    end
end

setmetatable(rac2, metatable)

saved_position = nil

rac2.save_position = function()
    saved_position = API:ReadMemory(ADDR_PLAYER_POS, 12)
end

rac2.load_position = function()
    if saved_position ~= nil then
        API:WriteMemory(ADDR_PLAYER_POS, saved_position)
    else
        Console.Warn('Tried to load position before saving')
    end
end

rac2.store_swingshot = function()
    Memory.WriteInt(ADDR_QUICK_SWITCH_ID, 0x0D)
end

rac2.go_to_ngplus = function()
    rac2.challenge_mode = 1
end
