package Day69;

import java.util.Arrays;

public class CoinSumInfinite {

	int[][] dp;
	int[] val;
	int[] wt;
	int W, N, ans = 0;
	double mod;

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		int[] A = { 1, 2, 3 };
		int B = 4;
		System.out.print(new CoinSumInfinite().coinchange2(A, B));
	}

	public int coinchange2(int[] A, int B) {
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

	public int coinchange22(int[] A, int B) {
		wt = A;
		N = A.length;
		W = B;
		mod = Math.pow(10, 6) + 7;
		dp = new int[N][W + 1];

		for (int i = 0; i < N; i++) {
			Arrays.fill(dp[i], -1);
		}
		return calc(0, 0);
	}

	public int calc(int i, int j) {

		if (i == N) {
			if (j == W)
				return 1;
			else
				return 0;
		}

		if (j > W)
			return 0;

		if (dp[i][j] != -1)
			return dp[i][j];

		int in = calc(i, j + wt[i]);
		int ex = calc(i + 1, j);
		ans = in + ex;

		dp[i][j] = ans;

		return (int) (ans % mod);
	}

}
