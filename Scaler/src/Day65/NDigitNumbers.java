package Day65;

public class NDigitNumbers {

	static int ans = 0;
	static int[] dp;
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		int A = 2;
		int B = 4;

	}
	
	public static int solve(int A, int B, int n) {
		
		if (A == 1) {
			return 1;
		}
		if (dp[n] != -1) {
			return dp[n];
		}
		ans = solve(A, B, n-1);
		
		if (ans == B) {
			dp[n] = 1;	
		}
		return ans;
	}

}
