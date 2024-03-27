package Day68;

import java.util.*;

public class UnbondedKnapsack {

	static int[][] dp; 
	static int [] val;
	static int [] wt;
	static int W, N, ans = 0;

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		val = new int[] { 60, 100, 120 };
		wt = new int[] { 10, 20, 30 };
		int C = 50;
		N = val.length;
		W = C;
		dp = new int[N][W];
		for (int i = 0; i < N; i++) {
			Arrays.fill(dp[i], -1);
		}
		int ans = calc(0, 0);

		System.out.println(ans);

	}

	public static int calc(int i, int wj) {

		if (i == N) {
			if (wj <= W) {
				return 0;
			} else {
				return Integer.MIN_VALUE;
			}
		}

		if (wj > W) {
			return Integer.MIN_VALUE;
		}
		if (dp[i][wj] != -1) {
			return dp[i][wj];
		}
		ans = calc(i + 1, wj);
		ans = Math.max(ans, val[i] + calc(i, wj + wt[i]));
		dp[i][wj] = ans;

		return ans;
	}

}
