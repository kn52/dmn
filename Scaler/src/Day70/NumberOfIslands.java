package Day70;

public class NumberOfIslands {

	public static void main(String[] args) {
		// TODO Auto-generated method stub

	}

	public int solve(int[][] A) {
        int count=0;
        for(int i=0;i<A.length;i++){
            for(int j=0;j<A[i].length;j++){
                if(A[i][j]==1){
                    count+=1;
                    dfs(A,i,j);
                }          
            }
        }
        return count;    
    }
   public void dfs(int[][] A, int i, int j) {
        if (i < 0 || j < 0 || i >= A.length || j >= A[i].length || A[i][j] == 0 || A[i][j] == -1) return;

        A[i][j] = -1;
        dfs(A, i + 1, j);
        dfs(A, i - 1, j);
        dfs(A, i, j - 1);
        dfs(A, i, j + 1);
        dfs(A, i - 1, j - 1);
        dfs(A, i + 1, j + 1);
        dfs(A, i - 1, j + 1);
        dfs(A, i + 1, j - 1);

   }
}
