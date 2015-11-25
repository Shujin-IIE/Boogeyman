public class Timer {
	private float CurrentTime;
	public float WakeTime;

	public Timer () {
		CurrentTime = 0f;
		WakeTime = 0f;
	}

	public Timer (float setTimer) {
		CurrentTime = 0f;
		WakeTime = setTimer;
	}

	public bool IsFinished () {
		return (CurrentTime >= WakeTime);
	}

	public void Reset () {
		CurrentTime = 0f;
	}

	public void UpdateTimer (float timePassedSinceLastCall) {
		CurrentTime += timePassedSinceLastCall;
	}
}
