package Day60;

import java.util.*;

public class ConnectingRopes {

	public static void main(String []args) {
		int[] A = new int[5];
		int ans = solve(A);
		System.out.print(ans);
	}
	
	public static int solve(int[] A) {
		int ans = 0;
		PriorityQueue<Integer> pe = new PriorityQueue<>();
		int n = A.length;
		for (int i = 0; i< n; i++) {
			pe.add(A[i]);
		}
		
		while(pe.size() > 1) {
			int f = pe.remove();
			int s = pe.remove();
			
			int sum = f + s;
			pe.add(sum);
			ans=+sum;
		}
		
		return ans;
	}
}
