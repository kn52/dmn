package Day64;

import java.util.*;

public class MaxSumWithoutAdjacentElement {

	public static void main(String[] args) {
		// TODO Auto-generated method stub

	}

	int[] dp;
    public int adjacent(int[][] A) {
        dp = new int[A[0].length];
        Arrays.fill(dp,-1);
        return calc(A,A[0].length-1);
    }

    public int calc(int[][] A, int i) {
         if(i < 0){
            return 0;
        }
        if(dp[i] != -1){
            return dp[i];
        }
        int inc = calc(A,i-2) + Math.max(A[0][i], A[1][i]);
        int exc = calc(A,i-1);
        int ans = Math.max(inc, exc);
        dp[i] = ans;
        return ans;
    }
}
