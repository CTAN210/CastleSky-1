using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserWorldsLoader : MonoBehaviour
{
    public UserWorlds userWorlds;
    void Start()
    {
        test();
    }

    public async void test()
    {
        UserWorlds userWorlds = await UserWorlds.loadUserWorlds(1);
        Debug.Log(userWorlds.userId + " " + userWorlds.Username);
        foreach(World world in userWorlds.Worlds) {
            Debug.Log(world.WorldId + " " + world.WorldName);
        }
    }
    
}
