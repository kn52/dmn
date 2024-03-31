package Day65;

import java.util.*;

public class UniquePathsInAGrid {

	public static void main(String[] args) {
		// TODO Auto-generated method stub

	}
	public int uniquePathsWithObstacles(int[][] A) {

        int[][]dp=new int[A.length][A[0].length];
        for(int i=0;i<A.length;i++){
            Arrays.fill(dp[i],-1);
        } 
        return ways(A,dp,A.length-1,A[0].length-1);
    }

    public int ways(int[][] a,int[][] dp,int i,int j){
        if(a[i][j]==1) return 0;
        if(i==0 && j==0) return 1;
        if(dp[i][j]!=-1) return dp[i][j];
        int up = (i==0) ? 0 : ways(a,dp,i-1,j);
        int left = (j==0) ? 0 : ways(a,dp,i,j-1);
        return dp[i][j]=up+left;
    }
}
