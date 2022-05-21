using UnityEngine;
using UnityEngine.Events;

public static class GameState {
	public enum GameStat {
		Menu = 2, Play = 0, Gameover = 1
	}

	private static GameStat current = GameStat.Menu;
	public delegate void GameEvent();
	public static GameEvent OnMenuEnter;
	public static GameEvent OnPlayEnter;
	public static GameEvent OnGameOverEnter;


	public static GameStat Current {
		get {
			Debug.Log( $"Get {current}" );
			return current;
		}

		set {
			Debug.Log( $"Set {value} > {current}" );


			if ( value == current ) {
				Debug.Log( $"Game stat is allready {current}" );
				return;
			}

			current = value;
			switch( current ) {
				default:
					OnMenuEnter?.Invoke();
					break;
				case GameStat.Play:
					OnPlayEnter?.Invoke();
					break;
				case GameStat.Gameover:
					OnGameOverEnter?.Invoke();
					break;
			}
		}
	}


	public static bool IsPlay() => current == GameStat.Play;
	public static bool IsGameOver() => current == GameStat.Gameover;
	public static bool IsMenu() => current == GameStat.Menu;


	public static void TriggerGameOver() {
		Current = GameStat.Gameover;
	}
}
