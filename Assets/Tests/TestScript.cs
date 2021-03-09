using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestScript
{
    private Game game;

    
    [SetUp]
    public void Setp()
    {
        GameObject gameGameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Game"));

        game = gameGameObject.GetComponent<Game>();
    }

    public void TearDown()
    {
        Object.Destroy(game.gameObject);
    }

    [UnityTest]
    public IEnumerator AsteroidSpawns()
    {
        GameObject asteroid = game.spawner.Spawn();

        yield return new WaitForSeconds(0.1f);

        Assert.IsNotNull(asteroid);
    }

    [UnityTest]
    public IEnumerator AsteroidMovesDown()
    {
        

       
        GameObject asteroid = game.spawner.Spawn();

        float initialYPos = asteroid.transform.position.y;


        yield return new WaitForSeconds(0.1f);

        Assert.Less(asteroid.transform.position.y, initialYPos);

        
    }
    
    [UnityTest]
    public IEnumerator GameOverOccursOnAsteroidCollision()
    {
        

        GameObject asteroid = game.spawner.Spawn();

        GameObject ship = game.player.ship;

        game.player = ship.GetComponent<PlayerMovement>();

        asteroid.transform.position = ship.transform.position;

        yield return new WaitForSeconds(0.1f);

        Assert.IsTrue(game.player.isGameOver);
    }
    
    [UnityTest]
    public IEnumerator LaserMovesUp()
    {
        //GameObject ship = player.ship;
        //player = ship.GetComponent<PlayerMovement>();
        GameObject laser = game.player.Shoot();

        float initialYPos = laser.transform.position.y;

        yield return new WaitForSecondsRealtime(0.1f);

        Assert.Greater(laser.transform.position.y, initialYPos);

    }
    [UnityTest]
    public IEnumerator DoesPlayerMove()
    {
        GameObject ship = game.player.ship;
        game.player = ship.GetComponent<PlayerMovement>();

        yield return new WaitForSeconds(0.1f);

        Assert.IsTrue(game.player.moving);
    }

}
