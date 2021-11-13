using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UserWorldsLoader : MonoBehaviour
{
    public UserWorlds userWorlds;
    void Start()
    {

    }

    public async void test()
    {
        int userClassId = Int32.Parse(CityEntrance.Scenes.getParam("userClassId"));
        UserWorlds userWorlds = await UserWorlds.loadUserWorlds(userClassId);
        Debug.Log(userWorlds.userId + " " + userWorlds.Username);
        foreach(World world in userWorlds.Worlds) {
            Debug.Log(world.WorldId + " " + world.WorldName);
        }
    }
    
}
