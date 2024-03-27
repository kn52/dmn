package Day68;

import java.util.*;

public class FlipArray {
	public int solve(final int[] A) {
		int sum = 0, n = A.length;
		for (int num : A)
			sum += num;
		sum = sum / 2;
		int[][] dp1 = new int[n][sum + 1];
		for (int[] arr : dp1)
			Arrays.fill(arr, -1);
		int maxSum = getMaxSum(n - 1, sum, A, dp1);
		int[][] dp2 = new int[n][maxSum + 1];
		for (int[] arr : dp2)
			Arrays.fill(arr, -1);
		return getMinCount(n - 1, maxSum, A, dp2);
	}

	private int getMaxSum(int i, int sum, int[] given, int[][] dp) {
		if (sum == 0)
			return 0;
		if (i == 0) {
			if (given[i] <= sum)
				return given[i];
			else
				return 0;
		}
		if (dp[i][sum] != -1)
			return dp[i][sum];
		int notFlip = getMaxSum(i - 1, sum, given, dp);
		if (given[i] <= sum) {
			dp[i][sum] = Math.max(notFlip, given[i] + getMaxSum(i - 1, sum - given[i], given, dp));
		} else {
			dp[i][sum] = notFlip;
		}
		return dp[i][sum];
	}

	private int getMinCount(int i, int sum, int[] given, int[][] dp) {
		if (sum == 0)
			return 0;
		if (i == 0) {
			if (given[0] == sum)
				return 1;
			else
				return 101;
		}
		if (dp[i][sum] != -1)
			return dp[i][sum];
		int notTake = getMinCount(i - 1, sum, given, dp);
		if (given[i] <= sum) {
			dp[i][sum] = Math.min(notTake, 1 + getMinCount(i - 1, sum - given[i], given, dp));
		} else {
			dp[i][sum] = notTake;
		}
		return dp[i][sum];
	}
}
