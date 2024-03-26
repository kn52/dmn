package Day59;

import java.util.*;

public class LargestSubarrayZeroSum {
	public static void main(String[] args) {
		// TODO Auto-generated method stub

	}
	
	public int solve(ArrayList<Integer> A) {
        int ans = 0, n = A.size();
        HashMap<Long, Integer> mp = new HashMap<>();
        long sum = 0;
        mp.put(sum, -1);
        for(int i=0; i<n; i++) {
            sum += A.get(i);
            if(mp.containsKey(sum)) {
                ans = Math.max(ans, i - mp.get(sum));
            }
            else {
                mp.put(sum, i);
            }
        }
        return ans;
    }
}
