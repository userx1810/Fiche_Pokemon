using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pokemon : MonoBehaviour
{
    public string _name = "Rondoudou"; // nom du pokemon
    public int defense = 20; // c'est pour sa défense
    public int attaque = 45; // ça, c'est pour son attaque
    public float poids = 5.5f; // son poids en float
    private int HP = 115; // ses points de vie
    
    public enum TypePokemon
    {
        Insecte,
        Tenebres,
        Dragon,
        Électrik,
        Fée,
        Feu,
        Combat,
        Vol,
        Acier,
        Poison
    }

    public TypePokemon[] types = { TypePokemon.Poison, TypePokemon.Acier, TypePokemon.Vol, TypePokemon.Combat, TypePokemon.Insecte, TypePokemon.Feu, TypePokemon.Fée, TypePokemon.Électrik, TypePokemon.Dragon, TypePokemon.Tenebres }; // les types de ce pokémon
    public TypePokemon[] faiblesses = { TypePokemon.Acier, TypePokemon.Poison }; // ses faiblesses
    public TypePokemon[] resistances = { TypePokemon.Tenebres, TypePokemon.Insecte }; // ses résistances
    private int CurrentLife; // la vie actuelle
    private int StatsPoints; // points de stats

    private void Start() // quand ça commence
    {
        InitStatsPoints(); // initialise les points de stats
        InitCurrentLife(); // initialise la vie actuelle

        int randomEnemyIndex = Random.Range(0, types.Length); // ennemi aléatoire
        TypePokemon randomEnemyType = types[randomEnemyIndex]; // type d'ennemi aléatoire
        int GetAttackDamage = 58; // dégats
        TakeDamage(GetAttackDamage, randomEnemyType); // il reçoit des dégats

        Debug.Log("Rondoudou affronte un Pokémon de type: " + randomEnemyType); // il affronte un ennemi de type aléatoire
    }
    private void Display(){
        Debug.Log(_name);
        Debug.Log(defense);
        Debug.Log(attaque);
        Debug.Log(poids);
        Debug.Log(HP);
        Debug.Log(types);
        Debug.Log(faiblesses);
        Debug.Log(resistances);
    }

    private void InitStatsPoints() // initialise les points de stats
    {
        StatsPoints = HP + attaque + defense; // points de stats
    }

    private void InitCurrentLife() // initialise la vie actuelle
    {
        CurrentLife = HP; // sa vie est au max au début
    }

    public void TakeDamage(int GetAttackDamage, TypePokemon ennemi) // il prend des dégats
    {
        int totalDegat = MultiplicationParDeux(GetAttackDamage, ennemi); // dégats total
        totalDegat = DivisionParDeux(totalDegat, ennemi); 
        CurrentLife -= totalDegat; // la vie est divisées par deux 

        if (totalDegat > 0) // si il prend des dégats
        {
            Debug.Log("Rondoudou a pris " + totalDegat + " de dégats !"); // il prend des dégats
            Debug.Log("HP de Rondoudou après cette attaque: " + CurrentLife); // sa vie après l'attaque
        }
        else 
        {
            Debug.Log("Rondoudou n'a pris aucun dégat"); // il prend pas de dégats
        }
        CheckIfPokemonAlive(); // vérifie si le pokémon est toujours en vie
    }

    private int MultiplicationParDeux(int GetAttackDamage, TypePokemon ennemi) // multiplication par deux
    {
        if (ennemi == TypePokemon.Acier || ennemi == TypePokemon.Poison) // s'il est faible face à
        {
            Debug.Log("Rondoudou est faible face à ce type de Pokémon !"); // il est faible face à
            return GetAttackDamage * 2; // ses dégats sont doublés
        } else 
        {
            return GetAttackDamage; // il prend des dégats normaux
        }
    }

    private int DivisionParDeux(int GetAttackDamage, TypePokemon ennemi) // 
    {
        if (ennemi == TypePokemon.Insecte || ennemi == TypePokemon.Tenebres) // s'il est résistant
        {
            Debug.Log("Rondoudou résiste à ce type de Pokémon !"); // il est resistant alors
            return GetAttackDamage / 2; // ses dégats sont divisés par deux
        }
        else // 
        {
            return GetAttackDamage; // il prend des dégats normaux
        }
    }

    private void CheckIfPokemonAlive() // verifie si le pokémon est toujours en vie
    {
        if (CurrentLife <= 0) // s'il a plus de vie
        {
            Debug.Log("Rondoudou n'est plus en état de continuer... "); // il est KO
        }
        else 
        {
            Debug.Log("Rondoudou tient le coup avec  " + CurrentLife + " d'HP "); // il est toujours vie
        }
    }
}
