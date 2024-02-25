package Day50;

import java.util.Stack;

public class NearestSmallerLeftElement {

	public static void main(String[] args) {
		String[] A = new String[] { "2", "1", "+", "3", "*"};
		int[] ans = prevSmaller(A);
		printElement(ans);
	}
	public static int[] prevSmaller(String[] A) {
        int n = A.length;
        int ans[] = new int[n];
        Stack<Integer> st = new Stack<Integer>();
        st.push(Integer.parseInt(A[0]));
        ans[0]=-1;

        for(int i=1; i<n; i++){
            while(st.size() > 0 && st.peek() >= Integer.parseInt(A[i])){
                st.pop();
            }

            if(st.size() == 0){
                ans[i] = -1;
            }
            else{
                ans[i] = st.peek();
            }
            st.push(Integer.parseInt(A[i]));
        }
        return ans;
    }
	public static void printElement(int[] A) { 
		for(int i=1; i<A.length; i++){
			System.out.print(A[i]);
		}
	}
}
