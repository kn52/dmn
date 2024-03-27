package Day69;

import java.util.Arrays;

public class CuttingRod {

	int[][] dp;
	int[] val;
	int[] wt;
	int W, N, ans = 0;
	double mod;

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		int[] A = { 1, 4, 2, 5, 6 };
		int B = A.length;
		System.out.print(new CuttingRod().coinchange2(A, B));
	}

	public int solve(int[] A) {
		int N = A.length;
		int[] dp = new int[N + 1];
		for (int i = 1; i <= N; i++) {
			for (int j = 1; j <= i; j++) {
				dp[i] = Math.max(dp[i], A[j - 1] + dp[i - j]);
			}
		}
		return dp[N];
	}

	public int coinchange22(int[] A, int B) {
		long mod = 1000007;
		long dp[] = new long[B + 1];
		dp[0] = 1;

		for (int i = 0; i < A.length; i++) {
			for (int j = A[i]; j <= B; j++) {
				dp[j] = (dp[j] % mod + dp[j - A[i]] % mod) % mod;
			}
		}

		return (int) dp[B];
	}

	public int coinchange2(int[] A, int B) {
		wt = A;
		N = A.length;
		W = B;
		mod = Math.pow(10, 6) + 7;
		dp = new int[N][W + 1];

		for (int i = 0; i < N; i++) {
			Arrays.fill(dp[i], -1);
		}
		return calc(0, W);
	}

	public int calc(int index, int j) {

		if (index == 0) {
			return j * wt[0];
		}

		int notCut = calc(index - 1, j);
		int cut = Integer.MIN_VALUE;
		int rod_length = index + 1;

		if (rod_length <= W)
			cut = wt[index] + calc(index, j - rod_length);

		return Math.max(notCut, cut);
	}

}
