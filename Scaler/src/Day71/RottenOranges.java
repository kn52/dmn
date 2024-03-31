package Day71;

import java.util.*;

public class RottenOranges {

	public static void main(String[] args) {
		// TODO Auto-generated method stub

	}
	
	public int solve(int[][] A) {
        int r = A.length;
        int c = A[0].length;
        int ans=0;
        int ones=0;
        Queue<Pair> q = new LinkedList<>();
        for(int i=0;i<r;i++){
            for(int j=0;j<c;j++){
               if(A[i][j]==2){
                  q.add(new Pair(i,j)); 
               } else if(A[i][j]==1){
                  ones++;
               }
            }
        }
        if(ones == 0){
            return 0;
        }
        while(!q.isEmpty()){
            int n=q.size();
            int row[]={0,-1,0,1};
            int col[]={-1,0,1,0};
            while(n>0){
                Pair p = q.poll();
                int x=p.x;
                int y=p.y;
                for(int k=0;k<4;k++){
                    int ni = x+row[k];
                    int nj = y+col[k];
                    if(ni<0||nj<0||ni>=r||nj>=c){
                        continue;
                    }
                    if(A[ni][nj]==1){
                        q.add(new Pair(ni,nj));
                        A[ni][nj]=2;
                        ones--;
                    }
                }
                n--;
            }
            if(q.size()>0){
                ans++;
            }
        }

        return ones==0?ans:-1;

    }

    class Pair{
        int x;
        int y;
        Pair(int x, int y){
            this.x=x;
            this.y=y;
        }
    }
}
