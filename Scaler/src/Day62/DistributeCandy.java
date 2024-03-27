package Day62;

import java.util.*;

public class DistributeCandy {

	public static void main(String[] args) {
		// TODO Auto-generated method stub

	}
	
	public int candy(int[] A) {
        int n=A.length, sum=0;
        int[] candies= new int[n];
        Arrays.fill(candies,1);
        for(int i=1;i<n;i++){
            if(A[i]>A[i-1]){
                candies[i]=candies[i-1]+1;
            }
        }
        for(int i=n-2;i>=0;i--) {
            if(A[i]>A[i+1]){
                candies[i] = Math.max(candies[i], candies[i+1] + 1);
            }
                }
        for(int i=0;i<n;i++){
            sum=sum+candies[i];
           
        }
        return sum;
    }

}
