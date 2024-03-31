package Day69;

import java.util.*;

public class ZeroOneKnapsackTwo {

	public int solve(int[] A, int[] B, int C) {
        int n = A.length ;

        int max = 0;
        for(int a : A){
            max += a ;
        }
        int[][] dp = new int[n+1][max+1] ;
        Arrays.fill(dp[0],(int)1e7);

        dp[0][0] = 0;

        for(int i=1; i<=n; i++){
            for(int j=1; j<=max; j++){
                int pick = dp[i-1][j] ;
                int skip = (int)1e7;
                if(j-A[i-1] >=0 )
                 skip = B[i-1] + dp[i-1][j-A[i-1]] ;
                dp[i][j] = Math.min(pick,skip);
            }
        }
        int ans = 0;
        for(int i=1; i<=max; i++)
         if(dp[n][i]<=C)
          ans = i ;
        return ans ;
    }
}
