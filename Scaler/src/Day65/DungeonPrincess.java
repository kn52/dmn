package Day65;

import java.util.*;

public class DungeonPrincess {

	public static void main(String[] args) {
		// TODO Auto-generated method stub

	}

	 public int calculateMinimumHP(int[][] A) {
	        int[][] dp = new int [A.length][A[0].length];
	        int m = A.length;
	        int n = A[0].length;
	         for (int i = 0; i < m; i++) {
	            Arrays.fill(dp[i], Integer.MAX_VALUE);
	        }

	        dp[m - 1][n - 1] = Math.max(1, 1 - A[m - 1][n - 1]);
	         
	        int row = m-1;
	        int col = n-2;
	        while(col>=0){
	            dp[row][col] = Math.max(1, dp[row][col+1]- A[row][col]);
	            col--;
	        }
	        row = m-2;
	        col = n-1;
	        while(row>=0){
	            dp[row][col] = Math.max(1, dp[row+1][col]-A[row][col]);
	            row--;
	        }
	        for(int i = m-2; i>=0; i--){
	            for(int j = m-2; j>=0 ;j--){
	                dp[i][j] = Math.max(1,Math.min(dp[i][j+1],dp[i+1][j])-A[i][j]);
	            }
	        }
	        return dp[0][0];
	    }
}
